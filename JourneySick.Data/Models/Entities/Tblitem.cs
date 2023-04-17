using System;
using System.Collections.Generic;

namespace JourneySick.Data.Models.Entities
{
    public partial class Tblitem
    {
        public string FldItemId { get; set; } = null!;
        public string? FldItemName { get; set; }
        public string? FldItemDescription { get; set; }
        public string? FldItemUsage { get; set; }
        public string? FldItemCategory { get; set; }
        public decimal? FldPriceMax { get; set; }
        public decimal? FldPriceMin { get; set; }
        public DateTime? FldCreateDate { get; set; }
        public string? FldCreateBy { get; set; }
        public DateTime? FldUpdateDate { get; set; }
        public string? FldUpdateBy { get; set; }
    }
}
