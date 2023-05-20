using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.Request;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;

namespace JourneySick.Business.IServices
{
    public interface ITripService
    {
        //Select list w paging
        public Task<AllTripDTO> GetAllTripsWithPaging(int pageIndex, int pageSize, string? tripName);
        //Select User
        public Task<TripRequest> GetTripById(string tripId);
        //Insert
        public Task<string> CreateTrip(CreateTripRequest tripVO, CurrentUserRequest currentUser);
        //Update
        public Task<string> UpdateTrip(TripRequest tripVO, CurrentUserRequest currentUser);
        //Delete
        public Task<int> DeleteTrip(string tripId);
        //Count this month
        public Task<TripStatisticResponse> TripStatistic();
    }
}
