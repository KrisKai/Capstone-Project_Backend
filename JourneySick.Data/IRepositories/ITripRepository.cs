using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;

namespace JourneySick.Data.IRepositories
{
    public interface ITripRepository
    { 
        //SELECT ALL
        public Task<List<TbltripVO>> GetAllTripsWithPaging(int pageIndex, int pageSize, string? tripName);
        //COUNT
        public Task<int> CountAllTrips(string? tripName);
        //SELECT LAST ONE
        public Task<string> GetLastOneId();
        //SELECT BY ID
        public Task<TbltripVO> GetTripById(string tripId);
        //CREATE
        public Task<int> CreateTrip(TbltripVO tbltripVO);
        //UPDATE
        public Task<int> UpdateTrip(TbltripVO tbltripVO);
        //DELETE
        public Task<int> DeleteTrip(string tripId);
        //UPDATE BUDGET
        public Task<int> UpdateTripBudget(TbltripVO tbltripVO);
        //COUNT THIS MONTH
        public Task<int> CountTripCreatedThisMonth();
    }
}
