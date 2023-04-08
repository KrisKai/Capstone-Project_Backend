using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.Entities.VO
{
    public class TblTripVO:Tbltripdetail
    {
        public string? FldTripName { get; set; }

        public decimal? FldTripBudget { get; set; }

        public string? FldTripDescription { get; set; }

        public DateTime FldEstimateStartTime { get; set; }

        public DateTime FldEstimateArrivalTime { get; set; }

        public string? FldTripStatus { get; set; }

        public int? FldTripMember { get; set; }

        public string FldTripPresenter { get; set; }
    }
}
