using System;
using System.Collections.Generic;

namespace JourneySick.Data.Models.Entities
{
    public partial class TripDetail
    {
        public string TripId { get; set; }
        public int? TripStartLocationId { get; set; }
        public int? TripDestinationLocationId { get; set; }
        public DateTime? EstimateStartDate { get; set; }
        public int? EstimateStartTime { get; set; }
        public DateTime? EstimateEndDate { get; set; }
        public int? EstimateEndTime { get; set; }
        public string? Distance { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
    }
}
