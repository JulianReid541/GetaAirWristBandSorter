using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GetAirWristBandSorter.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.Extensions.Caching.Memory;

namespace GetAirWristBandSorter.Controllers
{
    public class HomeController : Controller
    {
        private IMemoryCache cache;
        public HomeController(IMemoryCache cache) {
            this.cache = cache;
        }

        //Home Controller used to create the board.
        public IActionResult Index() {
            //Creates new Color Sheet with default values
            ColorSheet c = new ColorSheet();

            //if cache has the defauly value (meaning app has never been opened until now) set current time and day into cache
            if (cache.Get<DateTime>("timestamp") == default(DateTime))
                cache.Set<DateTime>("timestamp", DateTime.Today);

            //if the current day is greater then the day in cache or the current year doesn't match the cached year
            if (DateTime.Now.DayOfYear > cache.Get<DateTime>("timestamp").DayOfYear || DateTime.Now.Year != cache.Get<DateTime>("timestamp").Year) {
                //set the cache to the current day
                cache.Set<DateTime>("timestamp", DateTime.Today);

                //shuffle the board
                c.Shuffle();
            }

            //turns board into a list of string arrays
            List<string[]> strings = c.CreateSheet().ToList();

            //sends the board object to the view
            return View(strings);
        }
    }
}