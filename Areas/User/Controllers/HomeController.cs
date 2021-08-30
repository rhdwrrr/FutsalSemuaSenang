using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutsalSemuaSenang.Areas.User.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        [Area("User")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
