using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarlightProperties.Models;

namespace StarlightProperties.Data
{
    public class HomeDbContext : DbContext
    {
        public HomeDbContext (DbContextOptions<HomeDbContext> options)
            : base(options)
        {
        }

        public DbSet<StarlightProperties.Models.House> House { get; set; } = default!;
    }
}
