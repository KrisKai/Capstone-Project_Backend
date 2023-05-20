using System;
using System.Collections.Generic;

namespace JourneySick.Data.Models.Entities
{
    public partial class MapLocation
    {
        public int MapId { get; set; }
        public string Longitude { get; set; } = null!;
        public string Latitude { get; set; } = null!;
        public string? LocationName { get; set; }
    }
}
