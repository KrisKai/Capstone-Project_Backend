using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.Request;

namespace JourneySick.Business.IServices
{
    public interface ITripRouteService
    {
        //Select list w paging
        public Task<AllTripRouteDTO> GetAllTripRoutesWithPaging(int pageIndex, int pageSize, string? routeId, string tripId, DateTime? planDateTime);
        //Select Route
        public Task<TripRouteDTO> GetTripRouteById(int routeId);
        //insert
        public Task<int> CreateTripRoute(TripRouteRequest tripRouteDTO, CurrentUserObject currentUser);
        //update
        public Task<int> UpdateTripRoute(TripRouteRequest tripRouteDTO, CurrentUserObject currentUser);
        //update
        public Task<int> DeleteTripRoute(int routeId);

    }
}
