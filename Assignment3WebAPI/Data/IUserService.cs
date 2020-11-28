using System.Threading.Tasks;
using Assignment3WebAPI.Models;

namespace Assignment3WebAPI.Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string password);
    }
}