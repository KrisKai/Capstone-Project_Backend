using System;
using System.Collections.Generic;

namespace JourneySick.Data.Models.Entities
{
    public partial class Tblrouteplan
    {
        public int FldPlanId { get; set; }
        public int? FldRouteId { get; set; }
        public string? FldPlanDescription { get; set; }
    }
}
