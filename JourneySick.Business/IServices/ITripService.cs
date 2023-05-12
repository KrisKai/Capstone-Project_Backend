using JourneySick.Business.Models.DTOs;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;

namespace JourneySick.Business.IServices
{
    public interface ITripService
    {
        //Select list w paging
        public Task<AllTripDTO> GetAllTripsWithPaging(int pageIndex, int pageSize, string? tripName);
        //Select User
        public Task<TripVO> GetTripById(string tripId);
        //Insert
        public Task<string> CreateTrip(TripVO tripVO, CurrentUserObj currentUser);
        //Update
        public Task<string> UpdateTrip(TripVO tripVO, CurrentUserObj currentUser);
        //Delete
        public Task<int> DeleteTrip(string tripId);
        //Count this month
        public Task<TripStatisticResponse> TripStatistic();
    }
}
