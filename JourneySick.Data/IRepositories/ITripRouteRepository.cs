using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.IRepositories
{
    public interface ITripRouteRepository
    {
        //SELECT ALL
        public Task<List<TriprouteVO>> GetAllTripRoutesWithPaging(int pageIndex, int pageSize, string? routeId);
        public Task<int> CountAllTripRoutes(string? tripName);
        public Task<TripRoute> GetTripRouteById(int tripRouteId);
        //CREATE
        public Task<int> CreateTripRoute(TripRoute triproute);
        public Task<int> UpdateTripRoute(TripRoute triproute);
        public Task<int> DeleteTripRoute(int tripRouteId);
    }
}
