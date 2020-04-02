using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StandaloneLessons.Infrastructure;
using StandaloneLessons.Models;

namespace StandaloneLessons.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ChangeView]
        public IActionResult Privacy()
        {
            return View();
        }

        [ActionResultMix]
        public IActionResult ActionResultMix()
        {
            return View("Privacy");
        }

        //[TimeElapsed]
        [TimeElapsedAsync]
        public string ActionFilter()
        {
            return "Action Filter";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
