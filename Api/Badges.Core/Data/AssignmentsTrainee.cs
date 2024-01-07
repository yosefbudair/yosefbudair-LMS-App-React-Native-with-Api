using System;
using System.Collections.Generic;

namespace Badges.Core.Data
{
    public partial class AssignmentsTrainee
    {
        public decimal Atid { get; set; }
        public DateTime? Submitdate { get; set; }
        public decimal? Mark { get; set; }
        public decimal? Assignmentsid { get; set; }
        public decimal? Userid { get; set; }
        public string? Assignmenturl { get; set; }

        public virtual Assignment? Assignments { get; set; }
        public virtual User? User { get; set; }
    }
}
