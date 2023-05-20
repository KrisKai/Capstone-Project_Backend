using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.Request;

namespace JourneySick.Business.IServices
{
    public interface ITripPlanService
    {
        //Select list w paging
        public Task<AllTripPlanDTO> GetAllTripPlansWithPaging(int pageIndex, int pageSize, string? planId);
        //Select Plan
        public Task<TripPlanDTO> GetTripPlanById(int planId);
        //insert
        public Task<int> CreateTripPlan(TripPlanDTO tripPlanDTO, CurrentUserRequest currentUser);
        //update
        public Task<int> UpdateTripPlan(TripPlanDTO tripPlanDTO, CurrentUserRequest currentUser);
        //update
        public Task<int> DeleteTripPlan(int planId);

    }
}
