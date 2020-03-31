﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestClient.Models;

namespace RestClient.Controllers
{
    public class PagesController : Controller
    {
        // GET pages
        public async Task<IActionResult> Index()
        {
            List<Page> pages = new List<Page>();

            using(var httpClient = new HttpClient())
            {
                using var request = await httpClient.GetAsync("https://localhost:44348/api/pages");
                string response = await request.Content.ReadAsStringAsync();

                pages = JsonConvert.DeserializeObject<List<Page>>(response);
            }

            return View(pages);
        }

        // GET pages/edit/5
        public async Task<IActionResult> Edit(int id)
        {
            Page page = new Page();

            using (var httpClient = new HttpClient())
            {
                using var request = await httpClient.GetAsync(@"https://localhost:44348/api/pages/{id}");
                string response = await request.Content.ReadAsStringAsync();

                page = JsonConvert.DeserializeObject<Page>(response);
            }

            return View(page);
        }
    }
}