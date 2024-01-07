using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Badges.Core.Data;
using Badges.Core.Services;

namespace LearningHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTController : ControllerBase
    {
        private readonly IJWTService _jwtService;
       
        public JWTController(IJWTService jWTService)
        {
            _jwtService = jWTService;
            
        }

        [HttpPost]
        [Route("token")]
        public IActionResult UserLogin([FromBody] User login)
        {
            
            var token =  _jwtService.userLogin(login);

            if(token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }



    }
}
