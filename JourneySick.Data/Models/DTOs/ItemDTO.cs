using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs
{
    public class ItemDTO
    {
        public int? ItemId { get; set; }
        public string ItemName { get; set; } = null!;
        public string? ItemDescription { get; set; }
        public int CategoryId { get; set; }
        public decimal? PriceMin { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
    }
}
