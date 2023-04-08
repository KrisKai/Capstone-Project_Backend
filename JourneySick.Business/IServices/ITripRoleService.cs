using JourneySick.Business.Models.DTOs;
using JourneySick.Data.Models.DTOs;

namespace JourneySick.Business.IServices
{
    public interface ITripRoleService
    {
        //Select list w paging
        public Task<List<TripRoleDTO>> GetAllTripRolesWithPaging(int pageIndex, int pageSize, CurrentUserObj currentUser);
        //Select Role
        public Task<TripRoleDTO> GetTripRole(String roleId);
        //insert
        public Task<String> CreateTripRole(TripRoleDTO planLocationDTO);
        //update
        public Task<String> UpdateTripRole(TripRoleDTO planLocationDTO);
        //update
        public Task<String> DeleteTripRole(String locationId);

    }
}
