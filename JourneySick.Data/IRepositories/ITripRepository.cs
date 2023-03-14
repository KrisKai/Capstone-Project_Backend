using JourneySick.Data.Models.Entities;

namespace JourneySick.Data.IRepositories
{
    public interface ITripRepository
    {
        //CREATE
        public Task<int> CreateTrip(Tbltrip tbltrip);
        public Task<string> GetLastOneId();
        public Task<Tbltrip> GetTripById(string tripId);
        public Task<int> UpdateTrip(Tbltrip tbltrip);
        public Task<int> DeleteTrip(string tripId);
    }
}
