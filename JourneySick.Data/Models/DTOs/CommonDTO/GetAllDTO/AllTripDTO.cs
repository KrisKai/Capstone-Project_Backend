using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO
{
    public class AllTripDTO
    {
        public int numOfTrip { get; set; }
        public List<TripDTO> listOfTrip { get; set; }
    }
}
