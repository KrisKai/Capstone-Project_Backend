using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs
{
    public class TripRoleDTO
    {
        public int? RoleId { get; set; } = null!;

        public string? RoleName { get; set; }

        public string? Type { get; set; }

        public string? Description { get; set; }
    }
}
