using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.Request;

namespace JourneySick.Business.IServices
{
    public interface IFeedbackService
    {
        public Task<AllFeedbackDTO> GetAllFeedbacksWithPaging(int pageIndex, int pageSize, string? tripId);
        //SELECT BY ID
        public Task<FeedbackDTO> GetFeedbackById(int id);
        //CREATE
        public Task<int> CreateFeedback(FeedbackDTO feedbackDTO, CurrentUserObject currentUser);
        //UPDATE
        public Task<int> UpdateFeedback(FeedbackDTO feedbackDTO, CurrentUserObject currentUser);
        //DELETE
        public Task<int> DeleteFeedback(int id);
        public Task<AllFeedbackDTO> GetTopFeedback();
        public Task<int> IncreaseLike(int feedbackId, string status);
    }
}
