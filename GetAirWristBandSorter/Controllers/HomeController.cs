using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GetAirWristBandSorter.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace GetAirWristBandSorter.Controllers
{
    public class HomeController : Controller
    {

        public HomeController() {
        }

        public IActionResult Index() {
            ColorSheet c = new ColorSheet();
            List<string[]> strings = c.CreateSheet().ToList();
            return View(strings);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
