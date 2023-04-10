using JourneySick.Business.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO
{
    public class AllTripRoleDTO
    {
        public int NumOfRole { get; set; }
        public List<TripRoleDTO>? ListOfRole { get; set; }
        public CurrentUserObj CurrentUserObj { get; set; }
    }
}
