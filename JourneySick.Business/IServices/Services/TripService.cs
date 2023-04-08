using AutoMapper;
using JourneySick.Data.IRepositories;
using JourneySick.Data.IRepositories.Repositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.VO;
using Microsoft.Extensions.Logging;

namespace JourneySick.Business.IServices.Services
{
    public class TripService : ITripService
    {
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<TripService> _logger;

        public TripService(ITripRepository tripRepository, IMapper mapper, ILogger<TripService> logger)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<TripDTO> GetTripById(string tripId)
        {
            try
            {
                Tbltrip tbltrip = await _tripRepository.GetTripById(tripId);
                TripDTO tripDTO = _mapper.Map<TripDTO>(tbltrip);
                return tripDTO;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }

        }

        public async Task<String> CreateTrip(TripDTO tripDTO)
        {
            try
            {
                string lastOne = await _tripRepository.GetLastOneId();
                tripDTO.FldTripId = (int.Parse(lastOne)+1).ToString();
                tripDTO.FldTripStatus = "Active";
                Tbltrip tbltrip = _mapper.Map<Tbltrip>(tripDTO);
                int id = await _tripRepository.CreateTrip(tbltrip);
                return tripDTO.FldTripId;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<string> UpdateTrip(TripDTO tripDTO)
        {
            try
            {
                TripDTO getTrip = await GetTripById(tripDTO.FldTripId);
                
                if (getTrip != null)
                {
                    Tbltrip tbltrip = _mapper.Map<Tbltrip>(tripDTO);
                    int id = await _tripRepository.UpdateTrip(tbltrip);
                    return getTrip.FldTripId;
                }
                else
                {
                    return "fail";
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
            
        }

        public async Task<string> DeleteTrip(string tripId)
        {
            try
            {
                TripDTO getTrip = await GetTripById(tripId);

                if (getTrip != null)
                {
                    int id = await _tripRepository.DeleteTrip(tripId);
                    return "done";
                }
                else
                {
                    return "fail";
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<AllTripDTO> GetAllTripsWithPaging(int pageIndex, int pageSize, string? tripName)
        {
            AllTripDTO result = new();
            try
            {
                List<Tbltrip> tbltrips = await _tripRepository.GetAllTripsWithPaging(pageIndex, pageSize, tripName);
                // convert entity to dto
                List<TripVO> trips = _mapper.Map<List<TripVO>>(tbltrips);
                int count = await _tripRepository.CountAllTrips(tripName);
                result.listOfTrip = trips;
                result.numOfTrip = count;
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }
    }
}
