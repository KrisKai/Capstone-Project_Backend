using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs
{
    public class TripItemDTO
    {
        public int? ItemId { get; set; }
        public string TripId { get; set; } = null!;
        public string? ItemName { get; set; }
        public string? ItemDescription { get; set; }
        public decimal? PriceMin { get; set; }
        public decimal? PriceMax { get; set; }
        public int? CategoryId { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
    }
}
