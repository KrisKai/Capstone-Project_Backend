using System;
using System.Collections.Generic;

namespace JourneySick.Data.Models.Entities
{
    public partial class Tblitemcategory
    {
        public string FldCategoryId { get; set; } = null!;
        public string? FldCategoryName { get; set; }
        public string? FldCategoryDescription { get; set; }
        public DateTime? FldCreateDate { get; set; }
        public string? FldCreateBy { get; set; }
        public DateTime? FldUpdateDate { get; set; }
        public string? FldUpdateBy { get; set; }
    }
}
