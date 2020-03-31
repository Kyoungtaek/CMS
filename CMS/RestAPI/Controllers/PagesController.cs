using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    public class PagesController : ControllerBase
    {
        private readonly CmsContext context;

        public PagesController(CmsContext context)
        {
            this.context = context;
        }
    }
}