using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs
{
    public class ItemCategoryDTO
    {
        public int? FldItemId { get; set; }
        public string FldItemName { get; set; } = null!;
        public string? FldItemDescription { get; set; }
        public string? FldItemUsage { get; set; }
        public int FldCategoryId { get; set; }
        public decimal? FldPriceMax { get; set; }
        public decimal? FldPriceMin { get; set; }
        public int? FldQuantity { get; set; }
        public DateTime? FldCreateDate { get; set; }
        public string? FldCreateBy { get; set; }
        public DateTime? FldUpdateDate { get; set; }
        public string? FldUpdateBy { get; set; }
    }
}
