using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs.CommonDTO.Request
{
    public class CurrentUserRequest
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}
