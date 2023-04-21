using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs
{
    public class RoutePlanDTO
    {
        public int FldPlanId { get; set; }
        public int? FldRouteId { get; set; }
        public string? FldPlanDescription { get; set; }
    }
}
