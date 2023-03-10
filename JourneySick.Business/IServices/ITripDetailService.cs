using JourneySick.Data.Models.DTOs;

namespace JourneySick.Business.IServices
{
    public interface ITripDetailService
    {
        //Select list w paging
        public Task<List<TripDetailDTO>> GetAllTripDetailsWithPaging(int pageIndex, int pageSize, UserDetailDTO currentUser);
        //Select Location
        public Task<TripDetailDTO> GetTripDetailById(int locationId);
        //insert
        public Task<String> CreateTripDetail(TripDetailDTO tripDetailDTO);
        //update
        public Task<String> UpdateTripDetail(TripDetailDTO tripDetailDTO);
        //update
        public Task<String> DeleteTripDetail(int locationId);

    }
}
