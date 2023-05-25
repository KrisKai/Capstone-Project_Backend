using Microsoft.AspNetCore.Http;

namespace JourneySick.Data.Models.DTOs.CommonDTO.Request
{
    public class TripRequest
    {
        public string? TripId { get; set; } = null!;
        public string TripName { get; set; }
        public decimal TripBudget { get; set; }
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
    }

    public class CreateTripDetailRequest : TripRequest
    {
        public int? TripStartLocationId { get; set; }
        public int? TripDestinationLocationId { get; set; }
        public DateTime? EstimateStartDate { get; set; }
        public int? EstimateStartTime { get; set; }
        public DateTime? EstimateEndDate { get; set; }
        public int? EstimateEndTime { get; set; }
        public string? Distance { get; set; }
    }

    public class CreateTripRequest : CreateTripDetailRequest
    {
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public IFormFile? TripThumbnail { get; set; }
    }

    public class UpdateTripRequest : CreateTripRequest
    {
        public string TripId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
    }
}
