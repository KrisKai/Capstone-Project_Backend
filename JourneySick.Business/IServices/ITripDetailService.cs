using JourneySick.Business.Models.DTOs;
using JourneySick.Data.Models.DTOs;

namespace JourneySick.Business.IServices
{
    public interface ITripDetailService
    {
        //Select list w paging
        public Task<List<TripDetailDTO>> GetAllTripDetailsWithPaging(int pageIndex, int pageSize, CurrentUserObj currentUser);
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
