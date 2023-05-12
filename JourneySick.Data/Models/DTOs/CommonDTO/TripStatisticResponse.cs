using System;
namespace JourneySick.Data.Models.DTOs.CommonDTO
{
	public class TripStatisticResponse
	{
        public int tripCountThisYear { get; set; }
        public int tripCountThisMonth { get; set; }
        public string trendStatus { get; set; }
        public int countDiff { get; set; }
    }
}

