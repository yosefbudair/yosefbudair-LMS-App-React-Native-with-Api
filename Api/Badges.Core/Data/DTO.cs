using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges.Core.Data
{
    public class DTO
    {
        public decimal Ctid { get; set; }
        public decimal Userid { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Image { get; set; }
        public decimal? Roleid { get; set; }
        public decimal? Mark { get; set; }
    }
}
