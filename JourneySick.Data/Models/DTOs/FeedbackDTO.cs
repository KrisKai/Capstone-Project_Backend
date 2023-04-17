using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs
{
    public class FeedbackDTO
    {
        public int? FldFeedbackId { get; set; }
        public string FldTripId { get; set; }
        public string FldUserId { get; set; }
        public string? FldFeedback { get; set; }
        public float? FldRate { get; set; }
        public int? FldLike { get; set; }
        public int? FldDislike { get; set; }
        public string? FldLocationName { get; set; }
        public DateTime? FldCreateDate { get; set; }
        public string? FldCreateBy { get; set; }
        public DateTime? FldUpdateDate { get; set; }
        public string? FldUpdateBy { get; set; }
    }
}
