using JourneySick.Data.Models.DTOs.CommonDTO.Request;
using JourneySick.Data.Models.Entities.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO
{
    public class AllFeedbackDTO
    {
        public int NumOfFeedback { get; set; }
        public List<FeedbackVO>? ListOfFeedback { get; set; }
    }
}
