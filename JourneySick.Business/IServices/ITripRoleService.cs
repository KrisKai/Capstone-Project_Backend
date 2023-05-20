using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;

namespace JourneySick.Business.IServices
{
    public interface ITripRoleService
    {
        //Select list w paging
        public Task<AllTripRoleDTO> GetAllTripRolesWithPaging(int pageIndex, int pageSize, string? roleName);
        //Select Role
        public Task<TripRoleDTO> GetTripRoleById(int roleId);
        //insert
        public Task<int> CreateTripRole(TripRoleDTO planLocationDTO);
        //update
        public Task<int> UpdateTripRole(TripRoleDTO planLocationDTO);
        //update
        public Task<int> DeleteTripRole(int roleId);

    }
}
