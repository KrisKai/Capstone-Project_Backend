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
                List<TbltriprouteVO> tbltrips = await _tripRouteRepository.GetAllTripRoutesWithPaging(pageIndex, pageSize, routeId);
                // convert entity to dto
                List<TripRouteVO> trips = _mapper.Map<List<TripRouteVO>>(tbltrips);
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
                Tbltriproute tbltriproute = await _tripRouteRepository.GetTripRouteById(routeId);
                // convert entity to dto
                TripRouteDTO tripRouteDTO = _mapper.Map<TripRouteDTO>(tbltriproute);

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
                Tblmaplocation tblmaplocation = new Tblmaplocation();
                tblmaplocation.FldLatitude = tripRouteDTO.FldLatitude;
                tblmaplocation.FldLongitude = tripRouteDTO.FldLongitude;
                tblmaplocation.FldLocationName = tripRouteDTO.FldLocationName;
                await _mapLocationRepository.CreateMapLocation(tblmaplocation);
                int mapId = await _mapLocationRepository.GetLastOne();
                tripRouteDTO.FldMapId = mapId;
                Tbltriproute tbltriproute = _mapper.Map<Tbltriproute>(tripRouteDTO);
                int id = await _tripRouteRepository.CreateTripRoute(tbltriproute);
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
                TripRouteDTO getTrip = await GetTripRouteById((int)tripRouteDTO.FldRouteId);

                if (getTrip != null)
                {
                    Tbltriproute tbltriproute = _mapper.Map<Tbltriproute>(tripRouteDTO);
                    if (await _tripRouteRepository.UpdateTripRoute(tbltriproute) > 0)
                    {
                        Tblmaplocation getMap = await _mapLocationRepository.GetMapLocationById((int)tripRouteDTO.FldMapId);
                        if (getMap != null)
                        {
                            getMap.FldLatitude = tripRouteDTO.FldLatitude;
                            getMap.FldLongitude = tripRouteDTO.FldLongitude;
                            getMap.FldLocationName = tripRouteDTO.FldLocationName;
                            await _mapLocationRepository.UpdateMapLocation(getMap);
                        }
                        return (int)tripRouteDTO.FldRouteId;
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
                    if (await _tripRouteRepository.DeleteTripRoute(routeId) > 0)
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
