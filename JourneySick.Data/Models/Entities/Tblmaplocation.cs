using System;
using System.Collections.Generic;

namespace JourneySick.Data.Models.Entities
{
    public partial class Tblmaplocation
    {
        public int FldMapId { get; set; }
        public string FldLongitude { get; set; } = null!;
        public string FldLatitude { get; set; } = null!;
        public string? FldLocationName { get; set; }
    }
}
