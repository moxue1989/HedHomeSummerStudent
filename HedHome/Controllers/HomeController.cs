using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HedHome.Models;
using Microsoft.AspNetCore.Authorization;

namespace HedHome.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("FindCourses");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult FindCourses()
        {
            ViewData["active"] = "FindCourses";
            return View();
        }
        public IActionResult RateCourses()
        {
            ViewData["active"] = "RateCourses";
            return View();
        }
        public IActionResult Careers()
        {
            ViewData["active"] = "Careers";
            return View();
        }
    }
}
