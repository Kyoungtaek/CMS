using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StandaloneLessons.Models;

namespace StandaloneLessons.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IRepository repository;

        public ProductsController(IRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index()
        {
            return View(repository.Products);
        }

        public IActionResult Create()
        {
            repository.AddProduct(new Product { Name = "Apples", Price = 1.5M });

            return RedirectToAction("Index");
        }
    }
}