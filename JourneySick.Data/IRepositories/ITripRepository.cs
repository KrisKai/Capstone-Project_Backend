using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;

namespace JourneySick.Data.IRepositories
{
    public interface ITripRepository
    { 
        //SELECT ALL
        public Task<List<TripVO>> GetAllTripsWithPaging(int pageIndex, int pageSize, string? tripName);
        //COUNT
        public Task<int> CountAllTrips(string? tripName);
        //SELECT LAST ONE
        public Task<string> GetLastOneId();
        //SELECT BY ID
        public Task<TripVO> GetTripById(string tripId);
        //CREATE
        public Task<int> CreateTrip(TripVO tripVO);
        //UPDATE
        public Task<int> UpdateTrip(TripVO tripVO);
        //DELETE
        public Task<int> DeleteTrip(string tripId);
        //UPDATE BUDGET
        public Task<int> UpdateTripBudget(TripVO tripVO);
        //COUNT THE QUANTITY OF TRIP CREATED IN THIS MONTH
        public Task<int> CountTripCreatedThisMonth();
        //COUNT PREVIOUS MONTH
        public Task<int> CountTripCreatedPreviousMonth();
        //COUNT THIS YEAR
        public Task<int> CountTripCreatedThisYear();
    }
}
