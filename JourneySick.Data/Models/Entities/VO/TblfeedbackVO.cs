using System;
namespace JourneySick.Data.Models.Entities.VO
{
	public class TblfeedbackVO:Tblfeedback
	{
        public string FldUsername { get; set; } = null!;
        public string? FldEmail { get; set; }
        public string? FldTripName { get; set; }
    }
}

