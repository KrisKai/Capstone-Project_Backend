using System;
namespace JourneySick.Data.Models.Entities.VO
{
	public class FeedbackVO : Feedback
	{
        public string Username { get; set; } = null!;
        public string Email { get; set; }
        public string TripName { get; set; }
        public string Fullname { get; set; }
    }
}

