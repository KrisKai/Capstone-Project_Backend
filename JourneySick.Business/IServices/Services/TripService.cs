using AutoMapper;
using JourneySick.Business.Extensions.Firebase;
using JourneySick.Business.Helpers;
using JourneySick.Business.Helpers.Exceptions;
using JourneySick.Data.IRepositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.Request;
using JourneySick.Data.Models.DTOs.CommonDTO.Response;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;
using Microsoft.Extensions.Logging;
using MySqlX.XDevAPI.Common;

namespace JourneySick.Business.IServices.Services
{
    public class TripService : ITripService
    {
        private readonly ITripRepository _tripRepository;
        private readonly ITripDetailRepository _tripDetailRepository;
        private readonly IUserDetailRepository _userDetailRepository;
        private readonly IMapLocationRepository _mapLocationRepository;
        private readonly ITripItemRepository _tripItemRepository;
        private readonly ITripMemberRepository _tripMemberRepository;
        private readonly ITripRouteRepository _tripRouteRepository;
        private readonly IFirebaseStorageService _firebaseStorageService;
        private readonly IMapper _mapper;
        private readonly ILogger<TripService> _logger;

        public TripService(ITripRepository tripRepository,
            IMapper mapper,
            ITripDetailRepository tripDetailRepository,
            IUserDetailRepository userDetailRepository,
            IMapLocationRepository mapLocationRepository,
            ITripItemRepository tripItemRepository,
            ITripMemberRepository tripMemberRepository,
            ITripRouteRepository tripRouteRepository,
            ILogger<TripService> logger,
            IFirebaseStorageService firebaseStorageService)
        {
            _tripRepository = tripRepository;
            _tripDetailRepository = tripDetailRepository;
            _userDetailRepository = userDetailRepository;
            _mapLocationRepository = mapLocationRepository;
            _tripItemRepository = tripItemRepository;
            _tripMemberRepository = tripMemberRepository;
            _tripRouteRepository = tripRouteRepository;
            _firebaseStorageService = firebaseStorageService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<AllTripDTO> GetAllTripsWithPaging(int pageIndex, int pageSize, string? tripName)
        {
            AllTripDTO result = new();
            try
            {
                List<TripVO> trips = await _tripRepository.GetAllTripsWithPaging(pageIndex, pageSize, tripName);
                /*           // convert entity to dto
                           List<TripRequest> tripsDTOs = _mapper.Map<List<TripRequest>>(trips);*/
                foreach (TripVO tripVO in trips)
                {
                   /* MapLocation startmaplocation = await _mapLocationRepository.GetMapLocationById((int)tripVO.TripStartLocationId);
                    if (startmaplocation != null)
                    {
                        tripVO.StartLocationName = startmaplocation.LocationName;
                        tripVO.StartLatitude = startmaplocation.Latitude;
                        tripVO.StartLongitude = startmaplocation.Longitude;
                    }*/
                    MapLocation endmaplocation = await _mapLocationRepository.GetMapLocationById((int)tripVO.TripDestinationLocationId);
                    if (endmaplocation != null)
                    {
                        tripVO.EndLocationName = endmaplocation.LocationName;
                        tripVO.EndLatitude = endmaplocation.Latitude;
                        tripVO.EndLongitude = endmaplocation.Longitude;
                    }
                }
                int count = await _tripRepository.CountAllTrips(tripName);
                result.ListOfTrip = trips;
                result.NumOfTrip = count;
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<TripVO> GetTripById(string tripId)
        {
            try
            {
                TripVO trip = await _tripRepository.GetTripById(tripId);
                if(trip == null)
                {
                    throw new GetOneException("Something is wrong!!");
                }
                trip.EstimateStartDateStr = $"{trip.EstimateStartDate:MM/dd}";
                trip.EstimateEndDateStr = $"{trip.EstimateEndDate:MM/dd}";
                if(trip.EstimateStartTime > 0 && trip.EstimateStartTime <= 12)
                {
                    trip.EstimateStartTimeStr = trip.EstimateStartTime + " AM";
                }
                if(trip.EstimateStartTime==0||(trip.EstimateStartTime > 12 && trip.EstimateStartTime < 23))
                {
                    trip.EstimateStartTimeStr = trip.EstimateStartTime + " PM";
                }
                if (trip.EstimateEndTime > 0 && trip.EstimateEndTime <= 12)
                {
                    trip.EstimateEndTimeStr = trip.EstimateEndTime + " AM";
                }
                if (trip.EstimateEndTime == 0 || (trip.EstimateEndTime > 12 && trip.EstimateEndTime < 23))
                {
                    trip.EstimateEndTimeStr = (trip.EstimateEndTime - 12) + " PM";
                }
                /*MapLocation startmaplocation = await _mapLocationRepository.GetMapLocationById((int)trip.TripStartLocationId);
                if (startmaplocation != null)
                {
                    trip.StartLocationName = startmaplocation.LocationName;
                    trip.StartLatitude = startmaplocation.Latitude;
                    trip.StartLongitude = startmaplocation.Longitude;
                }*/
                MapLocation endmaplocation = await _mapLocationRepository.GetMapLocationById((int)trip.TripDestinationLocationId);
                if (endmaplocation != null)
                {
                    trip.EndLocationName = endmaplocation.LocationName;
                    trip.EndLatitude = endmaplocation.Latitude;
                    trip.EndLongitude = endmaplocation.Longitude;
                }
                return trip;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }

        }

        public async Task<int> CreateTrip(CreateTripRequest createTripRequest, CurrentUserObject currentUser)
        {
            try
            {
                createTripRequest.TripStatus = "ACTIVE";
                createTripRequest.CreateBy = (currentUser != null) ? currentUser.UserId : "TESTER";
                createTripRequest.CreateDate = DateTimePicker.GetDateTimeByTimeZone();
                /*MapLocation startmaplocation = new()
                {
                    Latitude = createTripRequest.StartLatitude,
                    Longitude = createTripRequest.StartLongitude,
                    LocationName = createTripRequest.StartLocationName
                };
                createTripRequest.TripStartLocationId = (int)await _mapLocationRepository.CreateMapLocation(startmaplocation);*/

                MapLocation endmaplocation = new()
                {
                    Latitude = createTripRequest.EndLatitude,
                    Longitude = createTripRequest.EndLongitude,
                    LocationName = createTripRequest.EndLocationName
                };
                createTripRequest.TripDestinationLocationId = (int)await _mapLocationRepository.CreateMapLocation(endmaplocation);

                TripVO tripVO = _mapper.Map<TripVO>(createTripRequest);
                tripVO.TripId = await GenerateTripID();
                if (createTripRequest.TripThumbnail != null)
                {
                    tripVO.TripThumbnail = await _firebaseStorageService.UploadTripThumbnail(createTripRequest.TripThumbnail, tripVO.TripId);
                }

                Task createTrip = _tripRepository.CreateTrip(tripVO);
                Task createTripDetail = _tripDetailRepository.CreateTripDetail(tripVO);

                TripMember tripMember = new();
                tripMember.TripId = tripVO.TripId;
                tripMember.UserId = currentUser.UserId;
                tripMember.Status = "ACTIVE";
                tripMember.Confirmation = "Y";
                tripMember.MemberRole = "HOST";
                tripMember.CreateBy = currentUser.UserId;
                tripMember.CreateDate = DateTimePicker.GetDateTimeByTimeZone();
                await _tripMemberRepository.CreateTripMember(tripMember);

                if (Task.WhenAll(createTrip, createTripDetail).IsCompletedSuccessfully)
                {
                    UserVO userVO = await _userDetailRepository.GetUserDetailById(createTripRequest.CreateBy);
                    userVO.TripCreated++;
                    if (await _userDetailRepository.UpdateTripQuantityCreated(userVO) > 0)
                    {
                        return 1;
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

        public async Task<string> UpdateTrip(UpdateTripRequest updateTripRequest, CurrentUserObject currentUser)
        {
            try
            {
                TripVO currentTrip = await GetTripById(updateTripRequest.TripId);

                if (currentTrip != null)
                {
                    updateTripRequest.UpdateBy = currentUser.UserId;
                    updateTripRequest.UpdateDate = DateTimePicker.GetDateTimeByTimeZone();
                    TripVO tripVO = _mapper.Map<TripVO>(updateTripRequest);
                    tripVO.TripId = updateTripRequest.TripId;
                    int id = await _tripRepository.UpdateTrip(tripVO);
                    int id_detail = await _tripDetailRepository.UpdateTripDetail(tripVO);
                    if (id >= 0 && id_detail >= 0)
                    {
                        /*MapLocation startmaplocation = new()
                        {
                            Latitude = updateTripRequest.StartLatitude,
                            Longitude = updateTripRequest.StartLongitude,
                            LocationName = updateTripRequest.StartLocationName,
                            MapId = (int)updateTripRequest.TripStartLocationId
                        };
                        await _mapLocationRepository.UpdateMapLocation(startmaplocation);*/
                        MapLocation endmaplocation = new()
                        {
                            Latitude = updateTripRequest.EndLatitude,
                            Longitude = updateTripRequest.EndLongitude,
                            LocationName = updateTripRequest.EndLocationName,
                            MapId = (int)updateTripRequest.TripDestinationLocationId
                        };
                        await _mapLocationRepository.UpdateMapLocation(endmaplocation);
                        return updateTripRequest.TripId;
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
                TripVO getTrip = await GetTripById(tripId);

                if (getTrip != null)
                {
                    if (await _tripRepository.DeleteTrip(tripId) > 0 && await _tripDetailRepository.DeleteTripDetail(tripId) > 0
                        && await _mapLocationRepository.DeleteMapLocation((int)getTrip.TripStartLocationId) > 0 && await _mapLocationRepository.DeleteMapLocation((int)getTrip.TripDestinationLocationId) > 0)
                    {
                        await _tripItemRepository.DeleteTripItemByTripId(tripId);
                        await _tripMemberRepository.DeleteTripMemberByTripId(tripId);
                        await _tripRouteRepository.DeleteTripMemberByTripId(tripId);
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
        private async Task<string> GenerateTripID()
        {
            try
            {
                string lastOne = await _tripRepository.GetLastOneId();
                if (lastOne != null)
                {
                    if (lastOne.Equals("0"))
                    {
                        return "TRIP_00000001";
                    }
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
                    if (countPreviousMonth == 0)
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

        public async Task<List<TripVO>> GetTripHistory(string userId)
        {
            try
            {
                List<TripVO> trips = await _tripRepository.GetTripHistoryByUserId(userId);
                if(trips.Count > 0)
                {
                    foreach (TripVO tripVO in trips)
                    {
                        // check status of trip
                        if (tripVO.TripStatus.Equals("ACTIVE") && DateTime.Compare((DateTime)tripVO.EstimateEndDate,DateTime.Now) < 0)
                        {
                            tripVO.TripStatus = "CLOSED";
                        }
                        tripVO.EstimateStartDateStr = $"{tripVO.EstimateStartDate:MMM dd}";
                        tripVO.EstimateEndDateStr = $"{tripVO.EstimateEndDate:MMM dd}";
                        MapLocation startmaplocation = await _mapLocationRepository.GetMapLocationById((int)tripVO.TripStartLocationId);
                        /*if (startmaplocation != null)
                        {
                            tripVO.StartLocationName = startmaplocation.LocationName;
                            tripVO.StartLatitude = startmaplocation.Latitude;
                            tripVO.StartLongitude = startmaplocation.Longitude;
                        }*/
                        MapLocation endmaplocation = await _mapLocationRepository.GetMapLocationById((int)tripVO.TripDestinationLocationId);
                        if (endmaplocation != null)
                        {
                            tripVO.EndLocationName = endmaplocation.LocationName;
                            tripVO.EndLatitude = endmaplocation.Latitude;
                            tripVO.EndLongitude = endmaplocation.Longitude;
                        }
                    }
                }
                return trips;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }
    }
}
