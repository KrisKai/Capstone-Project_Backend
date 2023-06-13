using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;

namespace JourneySick.Data.IRepositories
{
    public interface IFeedbackRepository
    {

        public Task<List<FeedbackVO>> GetAllFeedbacksWithPaging(int pageIndex, int pageSize, string? userName);

        public Task<int> CountAllFeedbacks(string? userName);

        public Task<Feedback> GetFeedbackById(int feedbackId);

        //CREATE
        public Task<long> CreateFeedback(Feedback feedback);

        //UPDATE
        public Task<int> UpdateFeedback(Feedback feedback);

        //DELETE
        public Task<int> DeleteFeedback(int userId);
        public Task<List<FeedbackVO>> GetTopFeedback();
        public Task<int> IncreaseLike(Feedback feedbackDTO, string status);
        public Task<int> CountFeedbackByCreatorId(string userId);
    }
}

