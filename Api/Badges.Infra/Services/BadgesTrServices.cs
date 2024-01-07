using Badges.Core.Common;
using Badges.Core.Data;
using Badges.Core.Repository;
using Badges.Core.Services;
using Dapper;
using System.Data;


namespace Badges.Infra.Services
{
    public class BadgesTrServices : IBadgesTrServices
    {
        private readonly IBadgesTrRepository _badgestrRepository;

        public BadgesTrServices(IBadgesTrRepository badgestrRepository)
        {
            _badgestrRepository = badgestrRepository;
        }

        public List<BadgesTrainee> GetAllBadges()
        {
            return _badgestrRepository.GetAllBadges();
        }
        public bool CreateBadgeTr(BadgesTrainee badge)
        {
            return _badgestrRepository.CreateBadgeTr(badge);
        }
        public bool UpdateBadgeTr(BadgesTrainee badge)
        {
            return _badgestrRepository.UpdateBadgeTr(badge);
        }
        public bool DeleteBadgeTr(int id)
        {
            return _badgestrRepository.DeleteBadgeTr(id);
        }
        public BadgesTrainee GetBadgeTrById(int id)
        {
            return _badgestrRepository.GetBadgeTrById(id);
        }

    }
}