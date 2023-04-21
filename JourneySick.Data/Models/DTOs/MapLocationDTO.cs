using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs
{
    public class MapLocationDTO
    {
        public int? FldMapId { get; set; }
        public string FldLongitude { get; set; } = null!;
        public string FldLatitude { get; set; } = null!;
        public string? FldLocationName { get; set; }
    }
}
