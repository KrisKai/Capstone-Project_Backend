using JourneySick.Data.Models.DTOs.CommonDTO.Request;
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
        public List<FeedbackRequest>? ListOfFeedback { get; set; }
    }
}
