using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs.CommonDTO.VO
{
    public class FeedbackVO:FeedbackDTO
    {
        public string FldUsername { get; set; } = null!;
        public string FldEmail { get; set; }
        public string FldTripName { get; set; }
    }
}
