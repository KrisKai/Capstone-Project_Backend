namespace JourneySick.Data.Models.DTOs.CommonDTO.VO
{
    public class TripVO: TripDetailDTO
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
