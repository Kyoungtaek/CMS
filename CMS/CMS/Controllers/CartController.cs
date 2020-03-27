using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    public class CartController : Controller
    {
        private readonly CmsContext context;

        public CartController(CmsContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}