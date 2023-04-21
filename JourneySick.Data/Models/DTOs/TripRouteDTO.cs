using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs
{
    public class TripRouteDTO
    {
        public int? FldRouteId { get; set; }
        public string? FldTripid { get; set; }
        public int? FldMapId { get; set; }
        public int? FldPriority { get; set; }
        public decimal? FldEstimateTime { get; set; }
        public decimal? FldDistance { get; set; }
    }
}
