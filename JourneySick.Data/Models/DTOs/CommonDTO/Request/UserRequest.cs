using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs.CommonDTO.Request
{
    public class UserRequest : UserDetailDTO
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Confirmation { get; set; }
        public DateTime SendDate { get; set; }
        public List<UserInterest> userInterestList { get; set; }
        public string? Avatar { get; set; }
        public IFormFile? AvatarFile { get; set; }
    }
}
