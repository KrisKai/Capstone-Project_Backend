using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.Entities.VO
{
    public class TripVO: TripDetail
    {
        public string? TripName { get; set; }

        public decimal? TripBudget { get; set; }

        public string? TripDescription { get; set; }

        public string? TripStatus { get; set; }

        public int? TripMember { get; set; }

        public string TripPresenter { get; set; }
    }
}
