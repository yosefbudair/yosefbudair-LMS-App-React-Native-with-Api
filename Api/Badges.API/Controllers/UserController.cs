using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Badges.Core.Data;
using Badges.Core.Services;

namespace Badges.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public List<User> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }

        [HttpPost]
        [Route("Create")]
        public bool CreateUser(User Users)
        {
            return _userService.CreateUser(Users);
        }

        [HttpPut]
        [Route("Update")]
        public bool UpdateUser(User Users)
        {
            return _userService.UpdateUser(Users);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteUser(int id)
        {
            return _userService.DeleteUser(id);
        }
        [HttpGet]
        [Route("GetUserById/{id}")]
        public User GetUserById(int id)
        {
            return _userService.GetUserById(id);
        }
    }
}
