using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.Entities.VO
{
    public class TriprouteVO:TripRoute
    {
        public string Longitude { get; set; } = null!;
        public string Latitude { get; set; } = null!;
        public string? LocationName { get; set; }
    }
}
