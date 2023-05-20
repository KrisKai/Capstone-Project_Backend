using Microsoft.AspNetCore.Http;

namespace JourneySick.Data.Models.DTOs.CommonDTO.VO
{
    public class TripRequest: TripDetailDTO
    {
        public string? TripName { get; set; }
        public decimal? TripBudget { get; set; }
        public string? TripDescription { get; set; }
        public string? TripStatus { get; set; }
        public int? TripMember { get; set; }
        public string TripPresenter { get; set; } = null!;
        public string StartLongitude { get; set; } = null!;
        public string StartLatitude { get; set; } = null!;
        public string? StartLocationName { get; set; }
        public string EndLongitude { get; set; } = null!;
        public string EndLatitude { get; set; } = null!;
        public string? EndLocationName { get; set; }
    }

    public class CreateTripRequest : TripRequest
    {
        public IFormFile? Thumbnail { get; set; }
    }
}
