using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.Entities.VO
{
    public class TbltripmemberVO:Tbltripmember
    {
        public string? FldFullname { get; set; }

        public string? FldEmail { get; set; }

        public string? FldPhone { get; set; }

        public string? fldRoleName { get; set; }
    }
}
