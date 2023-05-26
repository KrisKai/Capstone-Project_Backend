using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs
{
    public class TripRouteDTO
    {
        public int? RouteId { get; set; }
        public string? TripId { get; set; }
        public int? MapId { get; set; }
        public int? Priority { get; set; }
        public decimal? EstimateTime { get; set; }
        public decimal? Distance { get; set; }
    }
}
