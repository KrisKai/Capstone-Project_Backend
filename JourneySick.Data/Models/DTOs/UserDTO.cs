﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs
{
    public class UserDTO
    {
        public String? UserId { get; set; }
        public String? Username { get; set; }
        public String? Password { get; set; }
        public string? Confirmation { get; set; }
        public DateTime SendDate { get; set; }
        public string? Avatar { get; set; }
    }
}
