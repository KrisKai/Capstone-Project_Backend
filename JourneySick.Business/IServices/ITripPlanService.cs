using JourneySick.Business.Models.DTOs;
using JourneySick.Data.Models.DTOs;

namespace JourneySick.Business.IServices
{
    public interface ITripPlanService
    {
        //Select list w paging
        public Task<List<TripPlanDTO>> GetAllTripPlansWithPaging(int pageIndex, int pageSize, CurrentUserObj currentUser);
        //Select Plan
        public Task<TripPlanDTO> GetTripPlanById(int planId);
        //insert
        public Task<String> CreateTripPlan(TripPlanDTO tripPlanDTO);
        //update
        public Task<String> UpdateTripPlan(TripPlanDTO tripPlanDTO);
        //update
        public Task<String> DeleteTripPlan(int planId);

    }
}
