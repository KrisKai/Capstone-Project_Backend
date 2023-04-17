using System;
using System.Collections.Generic;

namespace JourneySick.Data.Models.Entities
{
    public partial class Tblplanlocation
    {
        public int FldPlanId { get; set; }
        public string? FldPlanLocationId { get; set; }
        public int? FldMapId { get; set; }
        public string? FldPlanLocationDescription { get; set; }
        public DateTime? FldLocationArrivalTime { get; set; }
        public DateTime? FldCreateDate { get; set; }
        public string? FldCreateBy { get; set; }
        public DateTime? FldUpdateDate { get; set; }
        public string? FldUpdateBy { get; set; }
    }
}
