using System;
using System.Collections.Generic;

namespace Badges.Core.Data
{
    public partial class Badge
    {
        public Badge()
        {
            BadgesTrainees = new HashSet<BadgesTrainee>();
        }

        public decimal Badgesid { get; set; }
        public string? Type { get; set; }
        public string? Text { get; set; }
        public string? Image { get; set; }
        public string? Criteria { get; set; }
        public string? Activecriteria { get; set; }

        public virtual ICollection<BadgesTrainee> BadgesTrainees { get; set; }
    }
}
