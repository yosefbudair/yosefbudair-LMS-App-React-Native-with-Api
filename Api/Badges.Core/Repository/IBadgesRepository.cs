using Badges.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges.Core.Repository
{
    public interface IBadgesRepository
    { 
    public List<Badge> GetAllBadges();

    public bool CreateBadge(Badge badge);
    public bool UdateBadge(Badge badge);
    public bool DeleteBadge(int id);
    public Badge GetBadgeById(int id);

    }
}
