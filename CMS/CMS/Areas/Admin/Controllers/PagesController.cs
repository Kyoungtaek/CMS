﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Infrastructure;
using CMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PagesController : Controller
    {
        private readonly CmsContext context;
        public PagesController(CmsContext context)
        {
            this.context = context;
        }

        // GET /admin/pages
        public async Task<IActionResult> Index()
        {
            IQueryable<Page> pages = from p in context.Pages orderby p.Sorting select p;

            List<Page> pagesList = await pages.ToListAsync();

            return View(pagesList);
        }

        // GET /admin/pages/details/5
        public async Task<IActionResult> Details(int id)
        {
            Page page = await context.Pages.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        // GET /admin/pages/create
        public IActionResult Create() => View();


        // POST /admin/pages/create
        [HttpPost]
        public async Task<IActionResult> Create(Page page)
        {
            if (ModelState.IsValid)
            {
                page.Slug = page.Title.ToLower().Replace(" ", "-");
                page.Sorting = 100;

                var slug = await context.Pages.FirstOrDefaultAsync(x => x.Slug.Equals(page.Slug));

                if (slug != null)
                {
                    ModelState.AddModelError("", "The Title already exists.");

                    return View(page);
                }

                context.Add(page);
                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(page);
        }

    }
}