using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs.CommonDTO.VO
{
    public class FeedbackVO:FeedbackDTO
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; }
        public string TripName { get; set; }
    }
}
