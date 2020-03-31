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

        public async Task<ActionResult<IEnumerable<Page>>> GetPages()
        {
            return await context.Pages.OrderBy(x => x.Sorting).ToListAsync();
        }
    }
}