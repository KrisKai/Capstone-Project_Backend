using JourneySick.Data.Models.DTOs;

namespace JourneySick.Business.IServices
{
    public interface ITripDetailService
    {
        //Select list w paging
        public Task<List<TripDetailDTO>> GetAllTripDetailsWithPaging(int pageIndex, int pageSize, UserDetailDTO currentUser);
        //Select Location
        public Task<TripDetailDTO> GetTripDetailById(string locationId);
        //insert
        public Task<string> CreateTripDetail(TripDetailDTO tripDetailDTO);
        //update
        public Task<string> UpdateTripDetail(TripDetailDTO tripDetailDTO);
        //update
        public Task<string> DeleteTripDetail(string locationId);

    }
}
