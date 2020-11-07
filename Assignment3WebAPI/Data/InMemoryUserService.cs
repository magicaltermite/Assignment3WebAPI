using System;
using System.Collections.Generic;
using System.Linq;
using Assignment3WebAPI.Models;

namespace Assignment3WebAPI.Data
{
    public class InMemoryUserService : IUserService
    {
        private List<User> users;

        public InMemoryUserService()
        {
            users = new[]
            {
                new User
                {
                    City = "Horsens",
                    Domain = "via.dk",
                    Password = "123",
                    Role = "Student",
                    BirthYear = 1990,
                    SecurityLevel = 5,
                    UserName = "Sonny"
                },
                new User
                {
                    City = "Horsens",
                    Domain = "via.dk",
                    Password = "123",
                    Role = "Student",
                    BirthYear = 1999,
                    SecurityLevel = 1,
                    UserName = "Markus"
                },
                
            }.ToList();
        }


        public User ValidateUser(string userName, string password)
        {
            User first = users.FirstOrDefault(user => user.UserName.Equals(userName));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }

            return first;
        }
    }
}