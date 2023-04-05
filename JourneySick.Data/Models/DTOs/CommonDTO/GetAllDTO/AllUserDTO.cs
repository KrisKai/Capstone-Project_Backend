using System;
using JourneySick.Data.Models.VO;

namespace JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO
{
    public class AllUserDTO
    {
        public int numOfUser { get; set; }
        public List<UserVO> listOfUser { get; set; }
    }
}

