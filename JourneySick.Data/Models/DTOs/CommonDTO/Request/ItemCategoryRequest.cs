using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs.CommonDTO.Request
{
    public class ItemCategoryRequest
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }

    public class CreateItemCategoryRequest : ItemCategoryRequest
    {
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; } = null!;
    }
    public class UpdateItemCategoryRequest : ItemCategoryRequest
    {
        public int CategoryId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
    }
}
