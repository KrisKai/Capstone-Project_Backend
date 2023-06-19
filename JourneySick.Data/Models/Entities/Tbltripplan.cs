using System;
using System.Collections.Generic;

namespace JourneySick.Data.Models.Entities
{
    public partial class Tbltripplan
    {
        public int FldPlanId { get; set; }
        public string? FldTripId { get; set; }
        public string? FldPlanDescription { get; set; }
        public DateTime? FldCreateDate { get; set; }
        public string? FldCreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? FldUpdateBy { get; set; }
    }
}
