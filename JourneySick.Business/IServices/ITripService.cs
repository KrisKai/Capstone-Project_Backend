using JourneySick.Data.Models.DTOs;

namespace JourneySick.Business.IServices
{
    public interface ITripService
    {
        //Select User
        public Task<TripDTO> GetTripById(int tripId);
        //insert
        public Task<int> CreateTrip(TripDTO tripDTO);
        //update
        public Task<String> UpdateTrip(TripDTO tripDTO);
        //update
        public Task<String> DeleteTrip(int tripId);
        //Select list w paging
        public Task<List<UserDTO>> GetAllTripsWithPaging(int pageIndex, int pageSize, UserDetailDTO currentUser);
    }
}
