using System;
using System.Collections.Generic;

namespace Badges.Core.Data
{
    public partial class Assignment
    {
        public Assignment()
        {
            AssignmentsTrainees = new HashSet<AssignmentsTrainee>();
            BadgesTrainees = new HashSet<BadgesTrainee>();
        }

        public decimal Assignmentsid { get; set; }
        public DateTime? Datecreate { get; set; }
        public DateTime? Deadline { get; set; }
        public string? Name { get; set; }
        public decimal? Mark { get; set; }
        public string? Description { get; set; }
        public decimal? Courseid { get; set; }

        public virtual Course? Course { get; set; }
        public virtual ICollection<AssignmentsTrainee> AssignmentsTrainees { get; set; }
        public virtual ICollection<BadgesTrainee> BadgesTrainees { get; set; }
    }
}
