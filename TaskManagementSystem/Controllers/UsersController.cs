
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using TaskManagementSystem.Data.DTOs;
using TaskManagementSystem.Data.Services;
using TaskManagementSystem.Models.Users;
using Task = TaskManagementSystem.Data.DTOs.Task;

namespace TaskManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private IConfiguration _config;
        public UsersController(IConfiguration config, IUserService userService)
        {
            _config = config;
            _userService = userService;
        }

        [HttpPost("/register",Name = "Register")]
        public User Register(UserRegister userInfo)
        {
            return _userService.Register(userInfo);
        }

        [HttpPost("/sign-in", Name = "SignIn")]
        public IActionResult Post(LoginRequest loginRequest)
        {
            User? user = _userService.ValidateUser(loginRequest.UserName, loginRequest.UserPassword);
            if (user != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Issuer"], null, expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);
                var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);
                return Ok(token);
            }
            return Content("Provided user name and password is incorrect");
        }
    }
}