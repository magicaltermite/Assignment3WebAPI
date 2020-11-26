using System.Collections.Generic;
using Assignment3WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment3WebAPI.Persistence
{
    public class AdultDbContext : DbContext
    {
        public DbSet<Adult> Adults { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            // Name of database
            optionsBuilder.UseSqlite("Data source = Adults.db");
        }
    }
}

