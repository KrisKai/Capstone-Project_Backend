﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs.CommonDTO.Request
{
    public class ChangePasswordRequest
    {
        public string? UserId { get; set; }
        public string? OldPassword { get; set; }
        public string? Password { get; set; }
    }
}
