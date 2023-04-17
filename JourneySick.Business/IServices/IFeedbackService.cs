using JourneySick.Business.Models.DTOs;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;

namespace JourneySick.Business.IServices
{
    public interface IFeedbackService
    {
        public Task<AllFeedbackDTO> GetAllFeedbacksWithPaging(int pageIndex, int pageSize, string? tripId);
        //SELECT BY ID
        public Task<FeedbackDTO> GetFeedbackById(int id);
        //CREATE
        public Task<int> CreateFeedback(FeedbackDTO feedbackDTO, CurrentUserObj currentUser);
        //UPDATE
        public Task<int> UpdateFeedback(FeedbackDTO feedbackDTO, CurrentUserObj currentUser);
        //DELETE
        public Task<int> DeleteFeedback(int id);
    }
}
