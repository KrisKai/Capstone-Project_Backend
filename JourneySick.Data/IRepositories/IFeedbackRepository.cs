using JourneySick.Data.Models.DTOs.CommonDTO.VO;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;

namespace JourneySick.Data.IRepositories
{
    public interface IFeedbackRepository
    {

        public Task<List<Models.Entities.VO.FeedbackVO>> GetAllFeedbacksWithPaging(int pageIndex, int pageSize, string? userName);

        public Task<int> CountAllFeedbacks(string? userName);

        public Task<Feedback> GetFeedbackById(int feedbackId);

        //CREATE
        public Task<int> CreateFeedback(Feedback feedback);

        //UPDATE
        public Task<int> UpdateFeedback(Feedback feedback);

        //DELETE
        public Task<int> DeleteFeedback(int userId);
        public Task<List<Models.Entities.VO.FeedbackVO>> GetTopFeedback();
        public Task<int> IncreaseLike(Feedback feedbackDTO, string status);
    }
}

