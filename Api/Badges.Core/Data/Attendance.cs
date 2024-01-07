using System;
using System.Collections.Generic;

namespace Badges.Core.Data
{
    public partial class Attendance
    {
        public Attendance()
        {
            AttendanceTrainees = new HashSet<AttendanceTrainee>();
        }

        public decimal Attendanceid { get; set; }
        public decimal? Courseid { get; set; }

        public virtual Course? Course { get; set; }
        public virtual ICollection<AttendanceTrainee> AttendanceTrainees { get; set; }
    }
}
