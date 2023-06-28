using System;
using System.Collections.Generic;

namespace JourneySick.Data.Models.Entities
{
    public partial class User
    {
        public string UserId { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Confirmation { get; set; }
        public DateTime? SendDate { get; set; }
        public string? Avatar { get; set; }
    }
}
