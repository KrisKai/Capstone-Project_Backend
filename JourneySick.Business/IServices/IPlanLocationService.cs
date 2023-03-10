using JourneySick.Data.Models.DTOs;

namespace JourneySick.Business.IServices
{
    public interface IPlanLocationService
    {
        //Select list w paging
        public Task<List<PlanLocationDTO>> GetAllLocationsWithPaging(int pageIndex, int pageSize, UserDetailDTO currentUser);
        //Select Location
        public Task<PlanLocationDTO> GetPlanLocationById(int locationId);
        //insert
        public Task<String> CreatePlanLocation(PlanLocationDTO planLocationDTO);
        //update
        public Task<String> UpdatePlanLocation(PlanLocationDTO planLocationDTO);
        //update
        public Task<String> DeletePlanLocation(int locationId, UserDetailDTO currentUser);

    }
}
