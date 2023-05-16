using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs
{
    public class TripDetailDTO
    {
        public string FldTripId { get; set; } = null!;
        public int? FldTripStartLocationId { get; set; }
        public int? FldTripDestinationLocationId { get; set; }
        public DateOnly? FldEstimateStartDate { get; set; }
        /// <summary>
        /// &apos;HH:MM&apos;
        /// </summary>
        public string? FldEstimateStartTime { get; set; }
        public DateOnly? FldEstimateEndDate { get; set; }
        /// <summary>
        /// &apos;HH:MM&apos;
        /// </summary>
        public string? FldEstimateEndTime { get; set; }
        public decimal? FldDistance { get; set; }
        public DateTime? FldCreateDate { get; set; }
        public string? FldCreateBy { get; set; }
        public DateTime? FldUpdateDate { get; set; }
        public string? FldUpdateBy { get; set; }
    }
}
