using System;
using System.Threading.Tasks;
using Assignment3WebAPI.Data;
using Assignment3WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService userService;

        public UsersController(IUserService userService) {
            this.userService = userService;
        }


        [HttpGet]
        public async Task<ActionResult<User>> GetUserValidation([FromQuery] string username, string password) {
            try {
                User user = userService.ValidateUser(username, password);
                Console.WriteLine(user.UserName);
                return user;
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
    }
}