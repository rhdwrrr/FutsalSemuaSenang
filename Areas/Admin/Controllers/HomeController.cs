using FutsalSemuaSenang.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutsalSemuaSenang.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext c)
        {
            _context = c;
            var role = _context.Roles.FirstOrDefault(x => x.Id == 1);
        }

        public IActionResult Index()
        {
            var data = _context.Booking.ToList();
            return View(data);
        }

        public IActionResult Terkonfirmasi()
        {
            var data = _context.Booking.ToList().Where(x => x.Status == true);
            return View(data);
        }

        public IActionResult BelumTerkonfirmasi()
        {
            var data = _context.Booking.ToList().Where(x => x.Status == false);
            return View(data);
        }

        public IActionResult Konfirmasi(Booking data)
        {
            if (ModelState.IsValid)
            {
                var finduser = _context.Booking.Find(data.Id);

                if (finduser == null)
                {
                    return NotFound();
                }

                finduser.Status = true;

                _context.Update(finduser);

                _context.SaveChanges();

                return RedirectToAction("BelumTerkonfirmasi");
            }

            return View();
        }

        public IActionResult BatalkanKonfirmasi(Booking data)
        {
            if (ModelState.IsValid)
            {
                var finduser = _context.Booking.Find(data.Id);

                if (finduser == null)
                {
                    return NotFound();
                }

                finduser.Status = false;

                _context.Update(finduser);

                _context.SaveChanges();

                return RedirectToAction("Terkonfirmasi");
            }

            return View();
        }

        //select Roles supaya hanya user yang tampil
        private Roles IdAdmin()
        {
            var role = _context.Roles.FirstOrDefault(x => x.Id == 1);
            return role;
        }

        public IActionResult AllUser()
        {
            var data = _context.User.ToList().Where(x => x.Role != IdAdmin());
            return View(data);
        }

        public IActionResult Aktif()
        {
            var data = _context.User.ToList().Where(x => x.Status == true && x.Role != IdAdmin());
            return View(data);
        }

        public IActionResult NonAktif()
        {
            var role = _context.Roles.FirstOrDefault(x => x.Id == 1);
            var data = _context.User.ToList().Where(x => x.Status == false && x.Role != IdAdmin());
            return View(data);
        }

        public IActionResult Aktifkan(UserId data)
        {
            if (ModelState.IsValid)
            {
                var finduser = _context.User.Find(data.Id);

                if (finduser == null)
                {
                    return NotFound();
                }

                finduser.Status = true;

                _context.Update(finduser);

                _context.SaveChanges();

                return RedirectToAction("NonAktif");
            }

            return View();
        }

        public IActionResult NonAktifkan(UserId data)
        {
            if (ModelState.IsValid)
            {
                var finduser = _context.User.Find(data.Id);

                if (finduser == null)
                {
                    return NotFound();
                }

                finduser.Status = false;

                _context.Update(finduser);

                _context.SaveChanges();

                return RedirectToAction("Aktif");
            }

            return View();
        }
    }
}