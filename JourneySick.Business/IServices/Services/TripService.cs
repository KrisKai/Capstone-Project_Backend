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
    public class TripService : ITripService
    {
        private readonly ITripRepository _tripRepository;
        private readonly ITripDetailRepository _tripDetailRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<TripService> _logger;

        public TripService(ITripRepository tripRepository, IMapper mapper, ITripDetailRepository tripDetailRepository, ILogger<TripService> logger)
        {
            _tripRepository = tripRepository;
            _tripDetailRepository = tripDetailRepository;
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
                return tripVO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }

        }

        public async Task<string> CreateTrip(TripVO tripVO)
        {
            try
            {
                tripVO.FldTripId = await GenerateUserID(); ;
                tripVO.FldTripStatus = "Active";
                tripVO.FldCreateBy = "Admin";
                tripVO.FldCreateDate = DateTime.Now;
                TbltripVO tbltrip = _mapper.Map<TbltripVO>(tripVO);
                if (await _tripRepository.CreateTrip(tbltrip) > 0 && await _tripDetailRepository.CreateTripDetail(tbltrip) > 0)
                {
                    return tripVO.FldTripId;
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

        public async Task<string> UpdateTrip(TripVO tripVO)
        {
            try
            {
                TripVO getTrip = await GetTripById(tripVO.FldTripId);

                if (getTrip != null)
                {
                    tripVO.FldUpdateBy = "Admin";
                    tripVO.FldUpdateDate = DateTime.Now;
                    TbltripVO tbltripVO = _mapper.Map<TbltripVO>(tripVO);
                    if (await _tripRepository.UpdateTrip(tbltripVO) > 0 && await _tripDetailRepository.UpdateTripDetail(tbltripVO) > 0)
                    {
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
                    if (await _tripRepository.DeleteTrip(tripId) > 0 && await _tripDetailRepository.DeleteTripDetail(tripId) > 0)
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

    }
}
