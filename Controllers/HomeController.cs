using FutsalSemuaSenang.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FutsalSemuaSenang.Controllers
{
    public class HomeController : Controller
    {        
        public IActionResult Index() => View();

        public IActionResult Login() => View();

        public IActionResult Daftar() => View();

        private readonly AppDbContext _context;

        public HomeController(AppDbContext c)
        {
            _context = c;
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind("Email,Password")] UserLogin data)
        {
            var user = _context.User
                .Where(x => x.Email == data.Email
                    && x.Password == data.Password)
                .Include(x => x.Role)
                .FirstOrDefault();

            if (user != null)
            {
                var claims = new List<Claim> {
                    new Claim("email", user.Email),
                    new Claim("role", user.Role.Name)
                };

                await HttpContext.SignInAsync(new ClaimsPrincipal(
                    new ClaimsIdentity(claims, "Cookies", "email", "role")
                    ));

                if (user.Role.Id == 1)
                {
                    return Redirect("/Admin");
                }
                else if (user.Role.Id == 2)
                {
                    return Redirect("/User");
                }

                return Redirect("/Home");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
