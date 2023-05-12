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
                List<TbltripVO> tbltrips = await _tripRepository.GetAllTripsWithPaging(pageIndex, pageSize, tripName);
                // convert entity to dto
                List<TripVO> trips = _mapper.Map<List<TripVO>>(tbltrips);
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
                TbltripVO tbltrip = await _tripRepository.GetTripById(tripId);
                TripVO tripVO = _mapper.Map<TripVO>(tbltrip);
                Tblmaplocation startmaplocation = await _mapLocationRepository.GetMapLocationById((int)tripVO.FldTripStartLocationId);
                if (startmaplocation != null)
                {
                    tripVO.FldStartLocationName = startmaplocation.FldLocationName;
                    tripVO.FldStartLatitude = startmaplocation.FldLatitude;
                    tripVO.FldStartLongitude = startmaplocation.FldLongitude;
                }
                Tblmaplocation endmaplocation = await _mapLocationRepository.GetMapLocationById((int)tripVO.FldTripDestinationLocationId);
                if (endmaplocation != null)
                {
                    tripVO.FldEndLocationName = endmaplocation.FldLocationName;
                    tripVO.FldEndLatitude = endmaplocation.FldLatitude;
                    tripVO.FldEndLongitude = endmaplocation.FldLongitude;
                }
                return tripVO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }

        }

        public async Task<string> CreateTrip(TripVO tripVO, CurrentUserObj currentUser)
        {
            try
            {
                tripVO.FldTripId = await GenerateUserID(); ;
                tripVO.FldTripStatus = "ACTIVE";
                tripVO.FldTripBudget = 0;
                tripVO.FldCreateBy = currentUser.UserId;
                tripVO.FldCreateDate = DateTimePicker.GetDateTimeByTimeZone();
                Tblmaplocation startmaplocation = new Tblmaplocation();
                startmaplocation.FldLatitude = tripVO.FldStartLatitude;
                startmaplocation.FldLongitude = tripVO.FldStartLongitude;
                startmaplocation.FldLocationName = tripVO.FldStartLocationName;
                await _mapLocationRepository.CreateMapLocation(startmaplocation);
                int startMapId = await _mapLocationRepository.GetLastOne();
                tripVO.FldTripStartLocationId = startMapId;
                Tblmaplocation endmaplocation = new Tblmaplocation();
                endmaplocation.FldLatitude = tripVO.FldEndLatitude;
                endmaplocation.FldLongitude = tripVO.FldEndLongitude;
                endmaplocation.FldLocationName = tripVO.FldEndLocationName;
                await _mapLocationRepository.CreateMapLocation(endmaplocation);
                int endMapId = await _mapLocationRepository.GetLastOne();
                tripVO.FldTripDestinationLocationId = endMapId;

                TbltripVO tbltrip = _mapper.Map<TbltripVO>(tripVO);
                if (await _tripRepository.CreateTrip(tbltrip) > 0 && await _tripDetailRepository.CreateTripDetail(tbltrip) > 0)
                {
                    TbluserVO tbluserVO = await _userDetailRepository.GetUserDetailById(tripVO.FldCreateBy);
                    tbluserVO.FldTripCreated++;
                    if (await _userDetailRepository.UpdateTripQuantityCreated(tbluserVO) > 0)
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

        public async Task<string> UpdateTrip(TripVO tripVO, CurrentUserObj currentUser)
        {
            try
            {
                TripVO getTrip = await GetTripById(tripVO.FldTripId);

                if (getTrip != null)
                {
                    tripVO.FldUpdateBy = currentUser.UserId;
                    tripVO.FldUpdateDate = DateTimePicker.GetDateTimeByTimeZone();
                    TbltripVO tbltripVO = _mapper.Map<TbltripVO>(tripVO);
                    if (await _tripRepository.UpdateTrip(tbltripVO) > 0 && await _tripDetailRepository.UpdateTripDetail(tbltripVO) > 0)
                    {
                        Tblmaplocation startmaplocation = new Tblmaplocation();
                        startmaplocation.FldLatitude = tripVO.FldStartLatitude;
                        startmaplocation.FldLongitude = tripVO.FldStartLongitude;
                        startmaplocation.FldLocationName = tripVO.FldStartLocationName;
                        startmaplocation.FldMapId = (int)tripVO.FldTripStartLocationId;
                        await _mapLocationRepository.UpdateMapLocation(startmaplocation);
                        Tblmaplocation endmaplocation = new Tblmaplocation();
                        endmaplocation.FldLatitude = tripVO.FldEndLatitude;
                        endmaplocation.FldLongitude = tripVO.FldEndLongitude;
                        endmaplocation.FldLocationName = tripVO.FldEndLocationName;
                        endmaplocation.FldMapId = (int)tripVO.FldTripDestinationLocationId;
                        await _mapLocationRepository.UpdateMapLocation(endmaplocation);
                        return tripVO.FldTripId;
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
                        && await _mapLocationRepository.DeleteMapLocation((int)getTrip.FldTripStartLocationId) > 0 && await _mapLocationRepository.DeleteMapLocation((int)getTrip.FldTripDestinationLocationId) > 0)
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
                TripStatisticResponse tripStatistic = new();
                tripStatistic.tripCountThisMonth = countThisMonth;
                tripStatistic.tripCountThisYear = countThisYear;
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
                        tripStatistic.trendStatus = "R";
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
