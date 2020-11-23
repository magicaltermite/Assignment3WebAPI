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
            optionsBuilder.UseSqlite(@"Data source = C:\Users\magic\Desktop\Mappe 1\VIA University\3 Semester\DNP1\Opgaver\Assignment 2 og 3\Web API\Assignment3WebAPI\Adults.db");
        }
    }
}