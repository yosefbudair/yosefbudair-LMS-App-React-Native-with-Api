using Badges.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges.Core.Repository
{
    public interface IBadgesTrRepository
    {

        public List<BadgesTrainee> GetAllBadges();
        public bool CreateBadgeTr(BadgesTrainee badge);
        public bool UpdateBadgeTr(BadgesTrainee badge);
        public bool DeleteBadgeTr(int id);
        public BadgesTrainee GetBadgeTrById(int id);

    }
}
