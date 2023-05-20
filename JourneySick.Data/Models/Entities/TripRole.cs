using System;
using System.Collections.Generic;

namespace JourneySick.Data.Models.Entities
{
    public partial class TripRole
    {
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
    }
}
