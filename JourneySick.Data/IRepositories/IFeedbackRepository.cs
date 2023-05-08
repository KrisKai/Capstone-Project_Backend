using JourneySick.Data.Models.DTOs.CommonDTO.VO;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;

namespace JourneySick.Data.IRepositories
{
    public interface IFeedbackRepository
    {

        public Task<List<TblfeedbackVO>> GetAllFeedbacksWithPaging(int pageIndex, int pageSize, string? userName);

        public Task<int> CountAllFeedbacks(string? userName);

        public Task<Tblfeedback> GetFeedbackById(int feedbackId);

        //CREATE
        public Task<int> CreateFeedback(Tblfeedback tblfeedback);

        //UPDATE
        public Task<int> UpdateFeedback(Tblfeedback tblfeedback);

        //DELETE
        public Task<int> DeleteFeedback(int userId);
        public Task<List<TblfeedbackVO>> GetTopFeedback();
    }
}

