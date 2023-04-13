using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs.CommonDTO.VO
{
    public class TripMemberVO: TripMemberDTO
    {
        public string? FldFullname { get; set; }

        public string? FldEmail { get; set; }

        public string? FldPhone { get; set; }

        public string? fldRoleName { get; set; }
    }
}
