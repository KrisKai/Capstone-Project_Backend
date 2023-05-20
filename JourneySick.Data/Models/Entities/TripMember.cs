using System;
using System.Collections.Generic;

namespace JourneySick.Data.Models.Entities
{
    public partial class TripMember
    {
        public int MemberId { get; set; }
        public string UserId { get; set; } = null!;
        public string TripId { get; set; } = null!;
        public string? MemberRoleId { get; set; }
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
