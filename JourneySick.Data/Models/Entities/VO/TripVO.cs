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
        public string? TripThumbnail { get; set; }
        public decimal? TripBudget { get; set; }
        public string? TripDescription { get; set; }
        public string? TripStatus { get; set; }
        public int? TripMember { get; set; }
        public string? TripPresenter { get; set; }
        public string? StartLongitude { get; set; } = null!;
        public string? StartLatitude { get; set; } = null!;
        public string? StartLocationName { get; set; }
        public string? EndLongitude { get; set; } = null!;
        public string? EndLatitude { get; set; } = null!;
        public string? EndLocationName { get; set; }
        public string? EstimateStartDateStr { get; set; }
        public string? EstimateEndDateStr { get; set; }
        public string? EstimateStartTimeStr { get; set; }
        public string? EstimateEndTimeStr { get; set; }
    }
}
