using System;
namespace JourneySick.Data.Models.Entities.VO
{
	public class TbluserVO:Tbluserdetail
	{
        public String? FldUsername { get; set; }
        public String? FldPassword { get; set; }
        public string? FldConfirmation { get; set; }
        public DateTime FldSendDate { get; set; }
    }
}

