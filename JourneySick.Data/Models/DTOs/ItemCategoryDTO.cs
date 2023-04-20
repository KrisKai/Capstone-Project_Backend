using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs
{
    public class ItemCategoryDTO
    {
        public int? FldCategoryId { get; set; }
        public string FldCategoryName { get; set; } = null!;
        public string? FldCategoryDescription { get; set; }
        public DateTime? FldCreateDate { get; set; }
        public string? FldCreateBy { get; set; } = null!;
        public DateTime? FldUpdateDate { get; set; }
        public string? FldUpdateBy { get; set; }
    }
}
