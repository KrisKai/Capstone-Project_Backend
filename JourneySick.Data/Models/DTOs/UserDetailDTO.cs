using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs
{
    public class UserDetailDTO
    {
        public string? UserId { get; set; } = null!;

        public string? Role { get; set; }

        public DateTime? Birthday { get; set; }

        public string? ActiveStatus { get; set; }

        public string? Email { get; set; }

        public string? Fullname { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public float? Experience { get; set; }

        public int? TripCreated { get; set; }

        public int? TripJoined { get; set; }

        public int? TripCompleted { get; set; }

        public int? TripCancelled { get; set; }

        public IFormFile? Avatar { get; set; }

        public DateTime? CreateDate { get; set; }

        public string? CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string? UpdateBy { get; set; }
    }
}
