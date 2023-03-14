using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs
{
    public class TripMemberDTO
    {
        public string? FldUserId { get; set; }

        public string? FldTripId { get; set; }

        public string? FldMemberRoleId { get; set; }

        public string? FldNickName { get; set; }

        public string? FldStatus { get; set; }

        public string? FldEmail { get; set; }

        public string? FldPhone { get; set; }

        public string? FldAddress { get; set; }

        public DateTime? FldCreateDate { get; set; }

        public string? FldCreateBy { get; set; }

        public DateTime? FldUpdateDate { get; set; }

        public string? FldUpdateBy { get; set; }
    }
}
