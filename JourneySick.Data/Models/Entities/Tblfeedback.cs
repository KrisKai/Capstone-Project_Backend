using System;
using System.Collections.Generic;

namespace JourneySick.Data.Models.Entities
{
    public partial class Tblfeedback
    {
        public int FldFeedbackId { get; set; }
        public string FldTripId { get; set; } = null!;
        public string FldUserId { get; set; } = null!;
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
