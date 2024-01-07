using Badges.Core.Data;
using Badges.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Badges.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BadgesTrController : ControllerBase
    {
        private readonly IBadgesTrServices _badgestrService;

        public BadgesTrController(IBadgesTrServices badgestrService)
        {
            _badgestrService = badgestrService;
        }


        [HttpGet]
        public List<BadgesTrainee> GetAllBadges()
        {
            return _badgestrService.GetAllBadges();
        }


        [HttpPost]
        [Route("Create")]
        public bool CreateBadgeTr(BadgesTrainee badge)
        {
            return _badgestrService.CreateBadgeTr(badge);
        }


        [HttpPut]
        [Route("Update")]
        public bool UpdateBadgeTr(BadgesTrainee badge)
        {
            return _badgestrService.UpdateBadgeTr(badge);
        }



        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteBadgeTr(int id)
        {
            return _badgestrService.DeleteBadgeTr(id);
        }




        [HttpGet]
        [Route("GetById/{id}")]
        public BadgesTrainee GetBadgeTrById(int id)
        {
            return _badgestrService.GetBadgeTrById(id);
        }
    }
}
