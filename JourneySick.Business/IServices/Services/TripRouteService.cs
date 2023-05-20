using AutoMapper;
using JourneySick.Business.Helpers.Exceptions;
using JourneySick.Business.Models.DTOs;
using JourneySick.Data.IRepositories;
using JourneySick.Data.IRepositories.Repositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;
using Microsoft.Extensions.Logging;

namespace JourneySick.Business.IServices.Services
{
    public class TripRouteService : ITripRouteService
    {
        private readonly ITripRouteRepository _tripRouteRepository;
        private readonly IMapLocationRepository _mapLocationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<TripRouteService> _logger;
        public TripRouteService(ITripRouteRepository tripRouteRepository, IMapLocationRepository mapLocationRepository, IMapper mapper, ILogger<TripRouteService> logger)
        {
            _tripRouteRepository = tripRouteRepository;
            _mapLocationRepository = mapLocationRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<AllTripRouteDTO> GetAllTripRoutesWithPaging(int pageIndex, int pageSize, string? routeId)
        {
            AllTripRouteDTO result = new();
            try
            {
                List<TriprouteVO> trips = await _tripRouteRepository.GetAllTripRoutesWithPaging(pageIndex, pageSize, routeId);
                // convert entity to dto
                List<TripRouteVO> trips = _mapper.Map<List<TripRouteVO>>(trips);
                int count = await _tripRouteRepository.CountAllTripRoutes(routeId);
                result.ListOfRoute = trips;
                result.NumOfRoute = count;
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<TripRouteDTO> GetTripRouteById(int routeId)
        {
            try
            {
                TripRoute triproute = await _tripRouteRepository.GetTripRouteById(routeId);
                // convert entity to dto
                TripRouteDTO tripRouteDTO = _mapper.Map<TripRouteDTO>(triproute);

                return tripRouteDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<int> CreateTripRoute(TripRouteVO tripRouteDTO, CurrentUserObj currentUser)
        {
            try
            {
                MapLocation maplocation = new()
                {
                    Latitude = tripRouteDTO.Latitude,
                    Longitude = tripRouteDTO.Longitude,
                    LocationName = tripRouteDTO.LocationName
                };
                await _mapLocationRepository.CreateMapLocation(maplocation);
                int mapId = await _mapLocationRepository.GetLastOne();
                tripRouteDTO.MapId = mapId;
                TripRoute triproute = _mapper.Map<TripRoute>(tripRouteDTO);
                int id = await _tripRouteRepository.CreateTripRoute(triproute);
                if (id > 0)
                {
                    return id;
                }
                throw new InsertException("Create trip route failed!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<int> UpdateTripRoute(TripRouteVO tripRouteDTO, CurrentUserObj currentUser)
        {
            try
            {
                TripRouteDTO getTrip = await GetTripRouteById((int)tripRouteDTO.RouteId);

                if (getTrip != null)
                {
                    TripRoute triproute = _mapper.Map<TripRoute>(tripRouteDTO);
                    if (await _tripRouteRepository.UpdateTripRoute(triproute) > 0)
                    {
                        MapLocation getMap = await _mapLocationRepository.GetMapLocationById((int)tripRouteDTO.MapId);
                        if (getMap != null)
                        {
                            getMap.Latitude = tripRouteDTO.Latitude;
                            getMap.Longitude = tripRouteDTO.Longitude;
                            getMap.LocationName = tripRouteDTO.LocationName;
                            await _mapLocationRepository.UpdateMapLocation(getMap);
                        }
                        return (int)tripRouteDTO.RouteId;
                    }
                    else
                    {
                        throw new UpdateException("Update trip route failed!");
                    }
                }
                else
                {
                    throw new GetOneException("Trip route is not existed!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<int> DeleteTripRoute(int routeId)
        {
            try
            {
                TripRouteDTO getTrip = await GetTripRouteById(routeId);

                if (getTrip != null)
                {
                    if (await _tripRouteRepository.DeleteTripRoute(routeId) > 0 && await _mapLocationRepository.DeleteMapLocation((int)getTrip.RouteId) > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        throw new DeleteException("Delete trip route failed!");
                    }

                }
                else
                {
                    throw new GetOneException("Trip route is not existed!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

    }
}
