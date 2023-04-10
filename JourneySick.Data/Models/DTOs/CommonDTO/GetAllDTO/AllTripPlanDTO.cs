using JourneySick.Business.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO
{
    public class AllTripPlanDTO
    {
        public int NumOfPlan { get; set; }
        public List<TripPlanDTO>? ListOfPlan { get; set; }
        public CurrentUserObj CurrentUserObj { get; set; }
    }
}
