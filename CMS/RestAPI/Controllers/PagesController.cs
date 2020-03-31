using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagesController : ControllerBase
    {
        private readonly CmsContext context;

        public PagesController(CmsContext context)
        {
            this.context = context;
        }

        // GET /api/pages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Page>>> GetPages()
        {
            return await context.Pages.OrderBy(x => x.Sorting).ToListAsync();
        }

        // GET /api/pages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Page>> GetPage(int id)
        {
            var page = await context.Pages.FindAsync(id);

            if (page == null)
            {
                return NotFound();
            }

            return page;
        }
    }
}