using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs.CommonDTO.VO
{
    public class TripRouteVO:TripRouteDTO
    {
        public string FldLongitude { get; set; } = null!;
        public string FldLatitude { get; set; } = null!;
        public string? FldLocationName { get; set; }
    }
}
