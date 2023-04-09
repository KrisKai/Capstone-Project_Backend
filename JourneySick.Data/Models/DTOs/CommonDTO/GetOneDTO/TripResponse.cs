using JourneySick.Data.Models.DTOs.CommonDTO.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs.CommonDTO.GetOneDTO
{
    public class TripResponse
    {
        public TripVO TripVO { get; set; }
        public string UserId { get; set; }
        public string Role { get; set; }
    }
}
