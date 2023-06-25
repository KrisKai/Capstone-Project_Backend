using System;
using System.Collections.Generic;

namespace JourneySick.Data.Models.Entities
{
    public partial class UserInterest
    {
        public int InterestId { get; set; }
        public string UserId { get; set; } = null!;
        public string? Interest { get; set; }
    }
}
