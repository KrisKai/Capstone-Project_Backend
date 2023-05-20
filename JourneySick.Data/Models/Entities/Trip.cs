using System;
using System.Collections.Generic;

namespace JourneySick.Data.Models.Entities
{
    public partial class Trip
    {
        public string TripId { get; set; } = null!;
        public string? TripName { get; set; }
        public decimal? TripBudget { get; set; }
        public string? TripDescription { get; set; }
        public string? TripStatus { get; set; }
        public int? TripMember { get; set; }
        public string TripPresenter { get; set; } = null!;
        public string? TripThumbnail { get; set; }
        public string? TripCompleted { get; set; }
    }
}
