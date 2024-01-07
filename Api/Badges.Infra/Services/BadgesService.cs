using Badges.Core.Data;
using Badges.Core.Repository;
using Badges.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges.Infra.Services
{
    public class BadgesService:IBadgesService
    {
        private readonly IBadgesRepository _badgesRepository;

        public BadgesService(IBadgesRepository badgesRepository)
        {
            _badgesRepository = badgesRepository;
        }
        public List<Badge> GetAllBadges() 
        {
            return _badgesRepository.GetAllBadges();
        }
        public bool CreateBadge(Badge badge) 
        {
            return _badgesRepository.CreateBadge(badge);
        }
        public bool UdateBadge(Badge badge) 
        {
            return _badgesRepository.UdateBadge(badge); 
        }
        public bool DeleteBadge(int id) 
        {
            return _badgesRepository.DeleteBadge(id);
        }
        public Badge GetBadgeById(int id) 
        {
            return _badgesRepository.GetBadgeById(id);
        }

    }
}
