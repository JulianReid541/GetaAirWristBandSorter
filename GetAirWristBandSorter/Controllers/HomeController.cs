using Microsoft.AspNetCore.Mvc;
using GetAirWristBandSorter.Models;
using System.Collections.Generic;
using System.Linq;

namespace GetAirWristBandSorter.Controllers
{
    public class HomeController : Controller
    {
        public HomeController() {
        }

        //Home Controller used to create the board.
        public IActionResult Index() {
            //Creates new Color Sheet with default values
            ColorSheet c = new ColorSheet();

            //turns board into a list of string arrays
            List<string[]> strings = c.CreateSheet().ToList();

            //sends the board object to the view
            return View(strings);
        }
    }
}
