using JourneySick.Data.Models.DTOs;

namespace JourneySick.Business.IServices
{
    public interface ITripService
    {
        //Select list w paging
        public Task<string> SelectAllTripWithPaging();
        //Select User
        public Task<TripDTO> SelectTrip(String tripId);
        //insert
        public Task<String> CreateTrip(TripDTO tripDTO);
        //update
        public Task<String> UpdateTrip(TripDTO tripDTO);
        //update
        public Task<String> DeleteTrip(String tripId);
    }
}
