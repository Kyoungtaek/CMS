using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StandaloneLessons.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "That page does not exist.";
                    break;
                default:
                    ViewBag.ErrorMessage = "There was a problem.";
                    break;
            }

            return View("NotFound");
        }
    }
}