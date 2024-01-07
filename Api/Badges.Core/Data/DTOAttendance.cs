using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges.Core.Data
{
    public class DTOAttendance
    {
        public decimal Atid { get; set; }
        public DateTime? Attendantedate { get; set; }
        public decimal? Checkat { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Attendanceid { get; set; }
        public decimal? Courseid { get; set; }
    }
}
