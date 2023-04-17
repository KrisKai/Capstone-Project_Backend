using System;
using System.Collections.Generic;

namespace JourneySick.Data.Models.Entities
{
    public partial class Tbltripitem
    {
        public string FldItemId { get; set; } = null!;
        public string FldTripId { get; set; } = null!;
        public string? FldItemName { get; set; }
        public string? FldItemDescription { get; set; }
        public decimal? FldPriceMin { get; set; }
        public decimal? FldPriceMax { get; set; }
        public string? FldItemCategory { get; set; }
        public DateTime? FldCreateDate { get; set; }
        public string? FldCreateBy { get; set; }
        public DateTime? FldUpdateDate { get; set; }
        public string? FldUpdateBy { get; set; }
    }
}
