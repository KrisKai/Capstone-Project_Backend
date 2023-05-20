using System;
using System.Collections.Generic;

namespace JourneySick.Data.Models.Entities
{
    public partial class Feedback
    {
        public int FeedbackId { get; set; }
        public string TripId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string? FeedbackDescription { get; set; }
        public float? Rate { get; set; }
        public int? Like { get; set; }
        public int? Dislike { get; set; }
        public string? LocationName { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
    }
}
