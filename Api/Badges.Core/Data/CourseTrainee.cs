using System;
using System.Collections.Generic;

namespace Badges.Core.Data
{
    public partial class CourseTrainee
    {
        public decimal Ctid { get; set; }
        public decimal? Mark { get; set; }
        public decimal? Courseid { get; set; }
        public decimal? Userid { get; set; }

        public virtual Course? Course { get; set; }
        public virtual User? User { get; set; }
    }
}
