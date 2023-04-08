using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs
{
    public class TripDetailDTO
    {
        public string? FldTripId { get; set; }

        public string? FldTripType { get; set; }

        public string? FldTripStartLocationName { get; set; }

        public string? FldTripStartLocationAddress { get; set; }

        public string? FldTripDestinationLocationName { get; set; }

        public string? FldTripDestinationLocationAddress { get; set; }

        public DateTime? FldCreateDate { get; set; }

        public string? FldCreateBy { get; set; }

        public DateTime? FldUpdateDate { get; set; }

        public string? FldUpdateBy { get; set; }
    }
}
