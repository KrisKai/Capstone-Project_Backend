using AutoMapper;
using JourneySick.Business.Helpers;
using JourneySick.Business.Helpers.Exceptions;
using JourneySick.Business.Models.DTOs;
using JourneySick.Data.IRepositories;
using JourneySick.Data.IRepositories.Repositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
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
                List<Data.Models.Entities.VO.TripVO> trips = await _tripRepository.GetAllTripsWithPaging(pageIndex, pageSize, tripName);
                // convert entity to dto
                List<Data.Models.DTOs.CommonDTO.VO.TripVO> tripsDTOs = _mapper.Map<List<Data.Models.DTOs.CommonDTO.VO.TripVO>>(trips);
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

        public async Task<Data.Models.DTOs.CommonDTO.VO.TripVO> GetTripById(string tripId)
        {
            try
            {
                Data.Models.Entities.VO.TripVO trip = await _tripRepository.GetTripById(tripId);
                Data.Models.DTOs.CommonDTO.VO.TripVO tripVO = _mapper.Map<Data.Models.DTOs.CommonDTO.VO.TripVO>(trip);
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

        public async Task<string> CreateTrip(CreateTripRequest tripVO, CurrentUserObj currentUser)
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

                Data.Models.Entities.VO.TripVO trip = _mapper.Map<Data.Models.Entities.VO.TripVO>(tripVO);
                long check = await _tripRepository.CreateTrip(trip);
                if (await _tripDetailRepository.CreateTripDetail(trip) > 0)
                {
                    Data.Models.Entities.VO.UserVO userVO = await _userDetailRepository.GetUserDetailById(tripVO.CreateBy);
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

        public async Task<string> UpdateTrip(Data.Models.Entities.VO.TripVO tripVO, CurrentUserObj currentUser)
        {
            try
            {
                Data.Models.DTOs.CommonDTO.VO.TripVO getTrip = await GetTripById(tripVO.TripId);

                if (getTrip != null)
                {
                    tripVO.UpdateBy = currentUser.UserId;
                    tripVO.UpdateDate = DateTimePicker.GetDateTimeByTimeZone();
                    Data.Models.Entities.VO.TripVO tripVO = _mapper.Map<Data.Models.Entities.VO.TripVO>(tripVO);
                    if (await _tripRepository.UpdateTrip(tripVO) > 0 && await _tripDetailRepository.UpdateTripDetail(tripVO) > 0)
                    {
                        maplocation startmaplocation = new maplocation();
                        startmaplocation.Latitude = tripVO.StartLatitude;
                        startmaplocation.Longitude = tripVO.StartLongitude;
                        startmaplocation.LocationName = tripVO.StartLocationName;
                        startmaplocation.MapId = (int)tripVO.TripStartLocationId;
                        await _mapLocationRepository.UpdateMapLocation(startmaplocation);
                        maplocation endmaplocation = new maplocation();
                        endmaplocation.Latitude = tripVO.EndLatitude;
                        endmaplocation.Longitude = tripVO.EndLongitude;
                        endmaplocation.LocationName = tripVO.EndLocationName;
                        endmaplocation.MapId = (int)tripVO.TripDestinationLocationId;
                        await _mapLocationRepository.UpdateMapLocation(endmaplocation);
                        return tripVO.TripId;
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
                Data.Models.DTOs.CommonDTO.VO.TripVO getTrip = await GetTripById(tripId);

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
