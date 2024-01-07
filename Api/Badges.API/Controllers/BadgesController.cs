using Badges.Core.Data;
using Badges.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Badges.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BadgesController : ControllerBase
    {

        private readonly IBadgesService _badgesService;

        public BadgesController(IBadgesService badgesService)
        {
            _badgesService = badgesService;
        }



        [HttpGet]
        public List<Badge> GetAllBadges()
        {
            return _badgesService.GetAllBadges();
        }
        // Yosef Ahmad



        [HttpPost]
        [Route("Create")]
        public bool CreateBadge(Badge badge)
        {
            return _badgesService.CreateBadge(badge);
        }



        [HttpPut]
        [Route("Update")]
        public bool UdateBadge(Badge badge)
        {
            return _badgesService.UdateBadge(badge);
        }



        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteBadge(int id)
        {
            return _badgesService.DeleteBadge(id);
        }




        [HttpGet]
        [Route("GetById/{id}")]
        public Badge GetBadgeById(int id)
        {
            return _badgesService.GetBadgeById(id);
        }
    }
}
