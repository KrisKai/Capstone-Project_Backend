using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs.CommonDTO.Request
{
    public class FeedbackRequest
    {
        public string TripId { get; set; }
        public string UserId { get; set; }
        public string? FeedbackDescription { get; set; }
        public float? Rate { get; set; }
        public string? LocationName { get; set; }
    }

    public class CreateFeedbackRequest : FeedbackRequest
    {
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
    }

    public class UpdateFeedbackRequest : FeedbackRequest
    {
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
        public int FeedbackId { get; set; }
    }
}
