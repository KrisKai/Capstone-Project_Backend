using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.Entities.VO
{
    public class TripmemberVO: TripMember
    {
        public string? Fullname { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? RoleName { get; set; }
    }
}
