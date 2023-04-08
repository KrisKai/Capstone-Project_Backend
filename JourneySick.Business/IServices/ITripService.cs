using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;

namespace JourneySick.Business.IServices
{
    public interface ITripService
    {
        //Select User
        public Task<TripVO> GetTripById(string tripId);
        //insert
        public Task<string> CreateTrip(TripVO tripVO);
        //update
        public Task<string> UpdateTrip(TripVO tripVO);
        //update
        public Task<int> DeleteTrip(string tripId);
        //Select list w paging
        public Task<AllTripDTO> GetAllTripsWithPaging(int pageIndex, int pageSize, string? tripName);
    }
}
