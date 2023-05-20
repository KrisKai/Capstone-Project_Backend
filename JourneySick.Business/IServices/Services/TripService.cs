using AutoMapper;
using JourneySick.Business.Helpers;
using JourneySick.Business.Helpers.Exceptions;
using JourneySick.Data.IRepositories;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.Request;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;
using Microsoft.Extensions.Logging;

namespace JourneySick.Business.IServices.Services
{
    public class TripService : ITripService
    {
        private readonly ITripRepository _tripRepository;
        private readonly ITripDetailRepository _tripDetailRepository;
        private readonly IUserDetailRepository _userDetailRepository;
        private readonly IMapLocationRepository _mapLocationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<TripService> _logger;

        public TripService(ITripRepository tripRepository, IMapper mapper, ITripDetailRepository tripDetailRepository, IUserDetailRepository userDetailRepository, IMapLocationRepository mapLocationRepository, ILogger<TripService> logger)
        {
            _tripRepository = tripRepository;
            _tripDetailRepository = tripDetailRepository;
            _userDetailRepository = userDetailRepository;
            _mapLocationRepository = mapLocationRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<AllTripDTO> GetAllTripsWithPaging(int pageIndex, int pageSize, string? tripName)
        {
            AllTripDTO result = new();
            try
            {
                List<TripVO> trips = await _tripRepository.GetAllTripsWithPaging(pageIndex, pageSize, tripName);
                // convert entity to dto
                List<TripRequest> tripsDTOs = _mapper.Map<List<TripRequest>>(trips);
                int count = await _tripRepository.CountAllTrips(tripName);
                result.ListOfTrip = tripsDTOs;
                result.NumOfTrip = count;
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<TripRequest> GetTripById(string tripId)
        {
            try
            {
                TripVO trip = await _tripRepository.GetTripById(tripId);
                TripRequest tripVO = _mapper.Map<TripRequest>(trip);
                MapLocation startmaplocation = await _mapLocationRepository.GetMapLocationById((int)tripVO.TripStartLocationId);
                if (startmaplocation != null)
                {
                    tripVO.StartLocationName = startmaplocation.LocationName;
                    tripVO.StartLatitude = startmaplocation.Latitude;
                    tripVO.StartLongitude = startmaplocation.Longitude;
                }
                MapLocation endmaplocation = await _mapLocationRepository.GetMapLocationById((int)tripVO.TripDestinationLocationId);
                if (endmaplocation != null)
                {
                    tripVO.EndLocationName = endmaplocation.LocationName;
                    tripVO.EndLatitude = endmaplocation.Latitude;
                    tripVO.EndLongitude = endmaplocation.Longitude;
                }
                return tripVO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }

        }

        public async Task<string> CreateTrip(CreateTripRequest tripVO, CurrentUserRequest currentUser)
        {
            try
            {
                tripVO.TripId = await GenerateUserID();
                tripVO.TripStatus = "ACTIVE";
                tripVO.TripBudget = tripVO.TripBudget;
                tripVO.CreateBy = tripVO.CreateBy;
                tripVO.CreateDate = DateTimePicker.GetDateTimeByTimeZone();
                MapLocation startmaplocation = new()
                {
                    Latitude = tripVO.StartLatitude,
                    Longitude = tripVO.StartLongitude,
                    LocationName = tripVO.StartLocationName
                };
                await _mapLocationRepository.CreateMapLocation(startmaplocation);
                int startMapId = await _mapLocationRepository.GetLastOne();
                tripVO.TripStartLocationId = startMapId;

                MapLocation endmaplocation = new()
                {
                    Latitude = tripVO.EndLatitude,
                    Longitude = tripVO.EndLongitude,
                    LocationName = tripVO.EndLocationName
                };
                await _mapLocationRepository.CreateMapLocation(endmaplocation);
                int endMapId = await _mapLocationRepository.GetLastOne();
                tripVO.TripDestinationLocationId = endMapId;

                TripVO trip = _mapper.Map<TripVO>(tripVO);
                long check = await _tripRepository.CreateTrip(trip);
                if (await _tripDetailRepository.CreateTripDetail(trip) > 0)
                {
                    UserVO userVO = await _userDetailRepository.GetUserDetailById(tripVO.CreateBy);
                    userVO.TripCreated++;
                    if (await _userDetailRepository.UpdateTripQuantityCreated(userVO) > 0)
                    {
                        return "1";
                    }
                    throw new InsertException("Something is wrong!!");
                }
                else
                {
                    throw new InsertException("Add trip failed!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<string> UpdateTrip(TripRequest tripRequest, CurrentUserRequest currentUser)
        {
            try
            {
                TripRequest getTrip = await GetTripById(tripRequest.TripId);

                if (getTrip != null)
                {
                    tripRequest.UpdateBy = currentUser.UserId;
                    tripRequest.UpdateDate = DateTimePicker.GetDateTimeByTimeZone();
                    TripVO tripVO = _mapper.Map<TripVO>(tripRequest);
                    if (await _tripRepository.UpdateTrip(tripVO) > 0 && await _tripDetailRepository.UpdateTripDetail(tripVO) > 0)
                    {
                        MapLocation startmaplocation = new MapLocation();
                        startmaplocation.Latitude = tripRequest.StartLatitude;
                        startmaplocation.Longitude = tripRequest.StartLongitude;
                        startmaplocation.LocationName = tripRequest.StartLocationName;
                        startmaplocation.MapId = (int)tripRequest.TripStartLocationId;
                        await _mapLocationRepository.UpdateMapLocation(startmaplocation);
                        MapLocation endmaplocation = new MapLocation();
                        endmaplocation.Latitude = tripRequest.EndLatitude;
                        endmaplocation.Longitude = tripRequest.EndLongitude;
                        endmaplocation.LocationName = tripRequest.EndLocationName;
                        endmaplocation.MapId = (int)tripRequest.TripDestinationLocationId;
                        await _mapLocationRepository.UpdateMapLocation(endmaplocation);
                        return tripRequest.TripId;
                    }
                    else
                    {
                        throw new UpdateException("Update trip failed!");
                    }
                }
                else
                {
                    throw new GetOneException("Trip is not existed!");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }

        }

        public async Task<int> DeleteTrip(string tripId)
        {
            try
            {
                TripRequest getTrip = await GetTripById(tripId);

                if (getTrip != null)
                {
                    if (await _tripRepository.DeleteTrip(tripId) > 0 && await _tripDetailRepository.DeleteTripDetail(tripId) > 0
                        && await _mapLocationRepository.DeleteMapLocation((int)getTrip.TripStartLocationId) > 0 && await _mapLocationRepository.DeleteMapLocation((int)getTrip.TripDestinationLocationId) > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        throw new DeleteException("Delete trip failed!");
                    }

                }
                else
                {
                    throw new GetOneException("User is not existed!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }
        private async Task<string> GenerateUserID()
        {
            try
            {
                string lastOne = await _tripRepository.GetLastOneId();
                if (lastOne != null)
                {
                    string lastId = lastOne.Substring(5);
                    int newId = Convert.ToInt32(lastId) + 1;
                    string newIdStr = Convert.ToString(newId);
                    while (newIdStr.Length < 8)
                    {
                        newIdStr = "0" + newIdStr;
                    }
                    return "TRIP_" + newIdStr;
                }
                else
                {
                    return "TRIP_00000001";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw new Exception(ex.Message);
            }

        }

        public async Task<TripStatisticResponse> TripStatistic()
        {
            try
            {
                int countThisMonth = await _tripRepository.CountTripCreatedThisMonth();
                int countPreviousMonth = await _tripRepository.CountTripCreatedPreviousMonth();
                int countThisYear = await _tripRepository.CountTripCreatedThisYear();
                TripStatisticResponse tripStatistic = new()
                {
                    tripCountThisMonth = countThisMonth,
                    tripCountThisYear = countThisYear
                };
                if (countThisMonth >= countPreviousMonth)
                {
                    if(countPreviousMonth == 0)
                    {
                        tripStatistic.countDiff = 100;
                        tripStatistic.trendStatus = "R";
                    }
                    else
                    {
                        tripStatistic.countDiff = countThisMonth / countPreviousMonth * 100;
                        tripStatistic.trendStatus = "R";
                    }
                }
                else
                {
                    if (countThisMonth == 0)
                    {
                        tripStatistic.countDiff = 100;
                        tripStatistic.trendStatus = "L";
                    }
                    else
                    {
                        tripStatistic.countDiff = countPreviousMonth / countThisMonth * 100;
                        tripStatistic.trendStatus = "L";
                    }
                }
                return tripStatistic;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }
    }
}
