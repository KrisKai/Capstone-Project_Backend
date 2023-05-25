using JourneySick.Data.Models.DTOs.CommonDTO.Request;

namespace JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO
{
    public class AllTripDTO
    {
        public int NumOfTrip { get; set; }
        public List<TripRequest>? ListOfTrip { get; set; }
    }
}
