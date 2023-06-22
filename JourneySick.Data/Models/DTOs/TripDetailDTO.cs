using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs
{
    public class TripDetailDTO
    {
        public string? TripId { get; set; } = null!;
        public int? TripDestinationLocationId { get; set; }
        public DateTime? EstimateStartDate { get; set; }
        public DateTime? EstimateEndDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
    }
}
