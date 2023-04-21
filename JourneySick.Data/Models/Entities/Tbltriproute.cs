using System;
using System.Collections.Generic;

namespace JourneySick.Data.Models.Entities
{
    public partial class Tbltriproute
    {
        public int FldRouteId { get; set; }
        public string? FldTripid { get; set; }
        public int? FldMapId { get; set; }
        public int? FldPriority { get; set; }
        public decimal? FldEstimateTime { get; set; }
        public decimal? FldDistance { get; set; }
    }
}
