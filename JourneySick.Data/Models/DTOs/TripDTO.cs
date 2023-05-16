using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs
{
    public class TripDTO
    {
        public string? FldTripId { get; set; } = null!;
        public string? FldTripName { get; set; }
        public decimal? FldTripBudget { get; set; }
        public string? FldTripDescription { get; set; }
        public string? FldTripStatus { get; set; }
        public int? FldTripMember { get; set; }
        public string FldTripPresenter { get; set; } = null!;
        public string FldTripCompleted { get; set; } = null!;
    }
}
