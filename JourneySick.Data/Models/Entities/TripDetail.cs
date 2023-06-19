using System;
using System.Collections.Generic;

namespace JourneySick.Data.Models.Entities
{
    public partial class TripDetail
    {
        public string TripId { get; set; } = null!;
        public int? TripStartLocationId { get; set; }
        public int? TripDestinationLocationId { get; set; }
        public DateTime EstimateStartDate { get; set; }
        /// <summary>
        /// &apos;HH:MM&apos;
        /// </summary>
        public string? EstimateStartTime { get; set; }
        public DateTime EstimateEndDate { get; set; }
        /// <summary>
        /// &apos;HH:MM&apos;
        /// </summary>
        public string? EstimateEndTime { get; set; }
        public string? Distance { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
    }
}
