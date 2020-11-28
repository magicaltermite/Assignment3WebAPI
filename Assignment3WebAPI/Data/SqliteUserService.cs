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
            
            
            
            if (first == null) {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password)) {
                throw new Exception("Incorrect password");
            }

            return first;
        }

        
        
    }
}