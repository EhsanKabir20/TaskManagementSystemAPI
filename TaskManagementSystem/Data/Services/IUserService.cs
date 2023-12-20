using TaskManagementSystem.Data.DTOs;
using TaskManagementSystem.Models.Users;

namespace TaskManagementSystem.Data.Services
{
    public interface IUserService
    {
        User? ValidateUser(string userName, string password);
        User Register(UserRegister userInfo);
    }
}
