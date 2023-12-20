using System.Threading.Tasks;
using TaskManagementSystem.Data.DTOs;
using TaskManagementSystem.Models.Users;

namespace TaskManagementSystem.Data.Services
{
    public class UserService : IUserService
    {
        private TMSContext _dbContext;
        private IHttpContextAccessor _httpContextAccessor;
        public UserService(TMSContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public User Register(UserRegister userInfo)
        {
            try
            {
                User user = new User() { UserName = userInfo.UserName, UserPassword = userInfo.UserPassword, UserRole = Enums.EnumUserRoles.Member };
                _dbContext.Add(user);
                _dbContext.SaveChanges();
                _dbContext.Add(new Contact() { Email = userInfo.Email, FirstName = userInfo.FirstName, LastName = userInfo.LastName, Trashed = false, UserId = user.UserId });
                _dbContext.SaveChanges();
                return user;
            }
            catch (Exception e)
            {
                _dbContext.Add(Log.ErrorLog(e.StackTrace, "Register User fails.", _httpContextAccessor));
                _dbContext.SaveChanges();
            }
            return null;
        }

        public User? ValidateUser(string userName, string password)
        {
            return _dbContext.Users.FirstOrDefault(user => user.UserName == userName && user.UserPassword == password);
        }
    }
}
