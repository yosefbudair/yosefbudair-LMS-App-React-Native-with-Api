using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges.Core.Data
{
    public class DTOC
    {
        public decimal Courseid { get; set; }
        public DateTime? Datefrom { get; set; }
        public DateTime? Dateto { get; set; }
        public string? Name { get; set; }
        public decimal? Duration { get; set; }
        public decimal? Sectionnum { get; set; }
        public string? Image { get; set; }
        public decimal? Userid { get; set; }
        public string? Coursenum { get; set; }

        public Decimal? Mark { get; set; }


    }
}
