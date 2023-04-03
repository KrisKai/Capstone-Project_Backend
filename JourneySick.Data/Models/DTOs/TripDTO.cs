using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs
{
    public class TripDTO
    {
        public string? FldTripId { get; set; }

        public string? FldTripName { get; set; }

        public decimal? FldTripBudget { get; set; }

        public string? FldTripDescription { get; set; }

        public DateTime? FldEstimateStartTime { get; set; }

        public DateTime? FldEstimateArrivalTime { get; set; }

        public string? FldTripStatus { get; set; }

        public int? FldTripMember { get; set; }
    }
}
