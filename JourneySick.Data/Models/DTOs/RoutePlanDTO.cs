using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs
{
    public class RoutePlanDTO
    {
        public int PlanId { get; set; }
        public int? RouteId { get; set; }
        public string? PlanDescription { get; set; }
    }
}
