using JourneySick.Data.Models.DTOs;

namespace JourneySick.Business.IServices
{
    public interface ITripPlanService
    {
        //Select list w paging
        public Task<List<TripPlanDTO>> SelectAllTripPlanWithPaging();
        //Select Plan
        public Task<TripPlanDTO> SelectTripPlan(String planId);
        //insert
        public Task<String> CreateTripPlan(TripPlanDTO tripPlanDTO);
        //update
        public Task<String> UpdateTripPlan(TripPlanDTO tripPlanDTO);
        //update
        public Task<String> DeleteTripPlan(String planId);

    }
}
