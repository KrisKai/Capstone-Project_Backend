using System;
using System.Collections.Generic;

namespace JourneySick.Data.Models.Entities
{
    public partial class PlanLocation
    {
        public int PlanId { get; set; }
        public string? PlanLocationId { get; set; }
        public int? MapId { get; set; }
        public string? PlanLocationDescription { get; set; }
        public DateTime? LocationArrivalTime { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
    }
}
