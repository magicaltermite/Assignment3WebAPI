using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment3WebAPI.Models;
using Assignment3WebAPI.Persistence;

namespace Assignment3WebAPI.Data
{
    public class SqliteUserService : IUserService
    {
        private AdultDbContext ctx;
        

        public SqliteUserService(AdultDbContext ctx) {
            this.ctx = ctx;
        }


        public User ValidateUser(string userName, string password)
        {
            User first = ctx.Users.FirstOrDefault(user => user.UserName.Equals(userName));
            
            if (ctx.Users == null) {
                InsertUser();
            }
            
            if (first == null) {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password)) {
                throw new Exception("Incorrect password");
            }

            return first;
        }

        private async Task InsertUser() {
            User sonny = new User {
                UserName = "Sonny",
                SecurityLevel = 5,
                Password = "123",
            };
            
            
            using (AdultDbContext dbCtx = new AdultDbContext()) {
                await dbCtx.Users.AddAsync(sonny);
                await dbCtx.SaveChangesAsync();
            }
        }
        
    }
}