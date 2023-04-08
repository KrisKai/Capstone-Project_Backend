using JourneySick.Data.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs.CommonDTO.VO
{
    public class UserVO : UserDetailDTO
    {
        public string? FldUsername { get; set; }
        public string? FldPassword { get; set; }
    }
}
