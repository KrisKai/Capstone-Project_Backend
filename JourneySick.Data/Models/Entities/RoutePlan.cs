using System;
using System.Collections.Generic;

namespace JourneySick.Data.Models.Entities
{
    public partial class RoutePlan
    {
        public int PlanId { get; set; }
        public int? RouteId { get; set; }
        public string? PlanDescription { get; set; }
    }
}
