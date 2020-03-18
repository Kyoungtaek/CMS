﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Infrastructure
{
    public class CmsContext:DbContext
    {
        public CmsContext(DbContextOptions<CmsContext> options):base(options)
        {

        }
    }
}
