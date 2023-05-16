using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs
{
    public class UserDTO
    {
        public String? FldUserId { get; set; }
        public String? FldUsername { get; set; }
        public String? FldPassword { get; set; }
        public string? FldConfirmation { get; set; }
        public DateTime? FldSendDate { get; set; }
    }
}
