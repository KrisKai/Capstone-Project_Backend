using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs
{
    public class TripPlanDTO
    {
        public string FldPlanId { get; set; } = null!;

        public string? FldTripId { get; set; }

        public string? FldPlanDescription { get; set; }

        public DateTime? FldCreateDate { get; set; }

        public string? FldCreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string? FldUpdateBy { get; set; }
    }
}
