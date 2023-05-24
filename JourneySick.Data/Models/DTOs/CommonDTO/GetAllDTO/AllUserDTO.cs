using JourneySick.Data.Models.DTOs.CommonDTO.Request;

namespace JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO
{
    public class AllUserDTO
    {
        public int NumOfUser { get; set; }
        public List<UserRequest> ListOfUser { get; set; }
    }
}

