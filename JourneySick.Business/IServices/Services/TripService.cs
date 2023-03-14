using AutoMapper;
using JourneySick.Data.IRepositories;
using JourneySick.Data.IRepositories.Repositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.VO;

namespace JourneySick.Business.IServices.Services
{
    public class TripService : ITripService
    {
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;

        public TripService(ITripRepository tripRepository, IMapper mapper)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
        }

        public async Task<TripDTO> GetTripById(string tripId)
        {
            Tbltrip tbltrip = await _tripRepository.GetTripById(tripId);
            TripDTO tripDTO = _mapper.Map<TripDTO>(tbltrip);
            return tripDTO;
        }

        public async Task<String> CreateTrip(TripDTO tripDTO)
        {
            try
            {
                string lastOne = await _tripRepository.GetLastOneId();
                tripDTO.FldTripId = lastOne;
                Tbltrip tbltrip = _mapper.Map<Tbltrip>(tripDTO);
                int id = await _tripRepository.CreateTrip(tbltrip);
                return lastOne;
            }
            catch (Exception ex)
            {
                throw new Exception();
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
                    return "";
                }
                else
                {
                    return "fail";
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            
        }

        public async Task<string> DeleteTrip(string tripId)
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

        public Task<List<TripDTO>> GetAllTripsWithPaging(int pageIndex, int pageSize, UserDetailDTO currentUser)
        {
            throw new NotImplementedException();
        }
    }
}
