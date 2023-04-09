using JourneySick.Data.Models.DTOs.CommonDTO.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO
{
    public class AllTripDTO
    {
        public int NumOfTrip { get; set; }
        public List<TripVO>? ListOfTrip { get; set; }
        public string UserId { get; set; }
        public string Role { get; set; }
    }
}
