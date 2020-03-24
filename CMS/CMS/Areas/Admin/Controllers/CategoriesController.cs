using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly CmsContext context;
        public CategoriesController(CmsContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await context.Categories.OrderBy(x=>x.Sorting).ToListAsync());
        }
    }
}