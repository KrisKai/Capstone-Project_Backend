using JourneySick.Data.Models.DTOs;

namespace JourneySick.Business.IServices
{
    public interface ITripService
    {
        //Select User
        public Task<TripDTO> GetTripById(string tripId);
        //insert
        public Task<String> CreateTrip(TripDTO tripDTO);
        //update
        public Task<String> UpdateTrip(TripDTO tripDTO);
        //update
        public Task<String> DeleteTrip(string tripId);
        //Select list w paging
        public Task<List<TripDTO>> GetAllTripsWithPaging(int pageIndex, int pageSize, UserDetailDTO currentUser);
    }
}
