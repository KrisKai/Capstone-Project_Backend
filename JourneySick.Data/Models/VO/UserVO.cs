using JourneySick.Data.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.VO
{
    public class UserVO : UserDetailDTO
    {
        public String? FldUsername { get; set; }
        public String? FldPassword { get; set; }
    }
}
