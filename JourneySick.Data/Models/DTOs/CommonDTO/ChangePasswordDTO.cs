using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs.CommonDTO
{
    public class ChangePasswordDTO
    {
        public string? FldUserId { get; set; }
        public string? FldOldPassword { get; set; }
        public string? FldPassword { get; set; }
    }
}
