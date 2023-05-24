using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs.CommonDTO.Request
{
    public class ItemRequest
    {
        public string ItemName { get; set; } = null!;
        public string? ItemDescription { get; set; }
        public string? ItemUsage { get; set; }
        public int CategoryId { get; set; }
        public decimal? PriceMax { get; set; }
        public decimal? PriceMin { get; set; }

    }

    public class CreateItemRequest : ItemRequest
    {
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
    }
    public class UpdateItemRequest : ItemRequest
    {
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }

        public int? ItemId { get; set; }
    }
}

