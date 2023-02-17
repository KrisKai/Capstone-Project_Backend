using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs
{
    public class TripRoleDTO
    {
        public string FldRoleId { get; set; } = null!;

        public string? FldRoleName { get; set; }

        public string? FldType { get; set; }

        public string? FldDescription { get; set; }
    }
}
