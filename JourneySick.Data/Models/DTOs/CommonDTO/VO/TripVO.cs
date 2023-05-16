using Microsoft.AspNetCore.Http;

namespace JourneySick.Data.Models.DTOs.CommonDTO.VO
{
    public class TripVO: TripDetailDTO
    {
        public string? FldTripName { get; set; }
        public decimal? FldTripBudget { get; set; }
        public string? FldTripDescription { get; set; }
        public string? FldTripStatus { get; set; }
        public int? FldTripMember { get; set; }
        public string FldTripPresenter { get; set; } = null!;
        public string FldStartLongitude { get; set; } = null!;
        public string FldStartLatitude { get; set; } = null!;
        public string? FldStartLocationName { get; set; }
        public string FldEndLongitude { get; set; } = null!;
        public string FldEndLatitude { get; set; } = null!;
        public string? FldEndLocationName { get; set; }
        public IFormFile? FldThumbnail { get; set; }
    }
}
