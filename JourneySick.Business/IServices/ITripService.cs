using JourneySick.Data.Models.DTOs;

namespace JourneySick.Business.IServices
{
    public interface ITripService
    {
        //Select list w paging
        public Task<List<TripDTO>> SelectAllTripsWithPaging();
        //Select User
        public Task<TripDTO> SelectTrip(int tripId);
        //insert
        public Task<int> CreateTrip(TripDTO tripDTO);
        //update
        public Task<String> UpdateTrip(TripDTO tripDTO);
        //update
        public Task<String> DeleteTrip(int tripId);
    }
}
