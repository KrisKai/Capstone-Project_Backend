
namespace JourneySick.Data.Models.DTOs
{
    public partial class UserInterestDTO
    {
        public int TripId { get; set; }
        public string UserId { get; set; } = null!;
        public string? Interest { get; set; }
    }
}
