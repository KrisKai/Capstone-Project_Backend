using JourneySick.Data.Models.DTOs.CommonDTO.VO;

namespace JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO
{
    public class AllTripMemberDTO
    {
        public int NumOfMember { get; set; }
        public List<TripMemberRequest>? ListOfMember { get; set; }
    }
}
