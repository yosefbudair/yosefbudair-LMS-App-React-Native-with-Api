using System;
using System.Collections.Generic;

namespace Badges.Core.Data
{
    public partial class BadgesTrainee
    {
        public decimal Btid { get; set; }
        public decimal? Courseid { get; set; }
        public decimal? Badgesid { get; set; }
        public decimal? Assignmentsid { get; set; }
        public decimal? Userid { get; set; }

        public virtual Assignment? Assignments { get; set; }
        public virtual Badge? Badges { get; set; }
        public virtual Course? Course { get; set; }
        public virtual User? User { get; set; }
    }
}
