using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs
{
    public class TripMemberDTO
    {
        public int? MemberId { get; set; } = null!;

        public string? UserId { get; set; }

        public string? TripId { get; set; }

        public int? MemberRoleId { get; set; }

        public string? NickName { get; set; }

        public string? Status { get; set; }

        public string? Confirmation { get; set; }

        public DateTime? SendDate { get; set; }

        public DateTime? CreateDate { get; set; }

        public string? CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string? UpdateBy { get; set; }
    }
}
