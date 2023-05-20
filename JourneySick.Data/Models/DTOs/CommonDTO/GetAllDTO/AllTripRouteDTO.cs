using JourneySick.Data.Models.DTOs.CommonDTO.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO
{
    public class AllTripRouteDTO
    {
        public int NumOfRoute { get; set; }
        public List<TripRouteRequest>? ListOfRoute { get; set; }
    }
}
