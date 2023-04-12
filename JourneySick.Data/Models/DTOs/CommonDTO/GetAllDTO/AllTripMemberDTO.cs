using JourneySick.Business.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO
{
    public class AllTripMemberDTO
    {
        public int NumOfMember { get; set; }
        public List<TripMemberDTO>? ListOfMember { get; set; }
    }
}
