using System;
using System.Collections.Generic;

namespace JourneySick.Data.Models.Entities
{
    public partial class TripRoute
    {
        public int RouteId { get; set; }
        public string? Tripid { get; set; }
        public int? MapId { get; set; }
        public int? Priority { get; set; }
        public decimal? EstimateTime { get; set; }
        public decimal? Distance { get; set; }
    }
}
