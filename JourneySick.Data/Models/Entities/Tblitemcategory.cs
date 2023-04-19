using System;
using System.Collections.Generic;

namespace JourneySick.Data.Models.Entities
{
    public partial class Tblitemcategory
    {
        public int FldCategoryId { get; set; }
        public string FldCategoryName { get; set; } = null!;
        public string? FldCategoryDescription { get; set; }
        public DateTime FldCreateDate { get; set; }
        public string FldCreateBy { get; set; } = null!;
        public DateTime? FldUpdateDate { get; set; }
        public string? FldUpdateBy { get; set; }
    }
}
