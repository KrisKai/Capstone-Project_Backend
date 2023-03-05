using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs
{
    public class PlanLocationDTO
    {
        public int? FldPlanId { get; set; }

        public int? FldOrdinal { get; set; }

        public string? FldPlanLocationId { get; set; }

        public string? FldPlanLocationName { get; set; }

        public string? FldPlanLocationDescription { get; set; }

        public DateTime? FldLocationArrivalTime { get; set; }

        public DateTime? FldCreateDate { get; set; }

        public string? FldCreateBy { get; set; }

        public DateTime? FldUpdateDate { get; set; }

        public string? FldUpdateBy { get; set; }
    }
}
