using System;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;

namespace JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO
{
    public class AllUserDTO
    {
        public int NumOfUser { get; set; }
        public List<UserVO> ListOfUser { get; set; }
        public string UserId { get; set; }
        public string Role { get; set; }
    }
}

