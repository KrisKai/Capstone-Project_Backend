using System;
using System.Collections.Generic;

namespace JourneySick.Data.Models.Entities
{
    public partial class TripPlan
    {
        public int PlanId { get; set; }
        public string? TripId { get; set; }
        public string? PlanDescription { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
    }
}
