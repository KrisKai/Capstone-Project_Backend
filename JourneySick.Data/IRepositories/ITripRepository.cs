using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;

namespace JourneySick.Data.IRepositories
{
    public interface ITripRepository
    { 
        //CREATE
        public Task<List<TbltripVO>> GetAllTripsWithPaging(int pageIndex, int pageSize, string? tripName);
        public Task<int> CountAllTrips(string? tripName);
        public Task<string> GetLastOneId();
        public Task<TbltripVO> GetTripById(string tripId);
        //CREATE
        public Task<int> CreateTrip(TbltripVO tbltripVO);
        //UPDATE
        public Task<int> UpdateTrip(TbltripVO tbltripVO);
        public Task<int> DeleteTrip(string tripId);
        public Task<int> UpdateTripBudget(TbltripVO tbltripVO);
    }
}
