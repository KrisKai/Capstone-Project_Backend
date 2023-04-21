using JourneySick.Business.Models.DTOs;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;

namespace JourneySick.Business.IServices
{
    public interface ITripRouteService
    {
        //Select list w paging
        public Task<AllTripRouteDTO> GetAllTripRoutesWithPaging(int pageIndex, int pageSize, string? routeId);
        //Select Route
        public Task<TripRouteDTO> GetTripRouteById(int routeId);
        //insert
        public Task<int> CreateTripRoute(TripRouteVO tripRouteDTO, CurrentUserObj currentUser);
        //update
        public Task<int> UpdateTripRoute(TripRouteVO tripRouteDTO, CurrentUserObj currentUser);
        //update
        public Task<int> DeleteTripRoute(int routeId);

    }
}
