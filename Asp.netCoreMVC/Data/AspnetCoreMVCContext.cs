using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Asp.netCoreMVC.Models;

namespace Asp.netCoreMVC.Data
{
    public class AspnetCoreMVCContext : DbContext
    {
        public AspnetCoreMVCContext (DbContextOptions<AspnetCoreMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
    }
}
