using System;
using System.Collections.Generic;

namespace Badges.Core.Data
{
    public partial class AttendanceTrainee
    {
        public decimal Atid { get; set; }
        public DateTime? Attendantedate { get; set; }
        public decimal? Checkat { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Attendanceid { get; set; }

        public virtual Attendance? Attendance { get; set; }
        public virtual User? User { get; set; }
    }
}
