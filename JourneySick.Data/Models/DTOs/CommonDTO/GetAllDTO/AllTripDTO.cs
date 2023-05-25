using JourneySick.Data.Models.DTOs.CommonDTO.Request;
using JourneySick.Data.Models.Entities.VO;

namespace JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO
{
    public class AllTripDTO
    {
        public int NumOfTrip { get; set; }
        public List<TripVO>? ListOfTrip { get; set; }
    }
}
