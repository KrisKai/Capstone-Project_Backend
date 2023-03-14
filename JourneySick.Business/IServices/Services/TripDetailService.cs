using AutoMapper;
using JourneySick.Data.IRepositories;
using JourneySick.Data.IRepositories.Repositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.VO;
using RevenueSharingInvest.Business.Exceptions;

namespace JourneySick.Business.IServices.Services
{
    public class TripDetailService : ITripDetailService
    {
        private readonly ITripDetailRepository _tripDetailRepository;
        private readonly IMapper _mapper;

        public TripDetailService(ITripDetailRepository tripDetailRepository, IMapper mapper)
        {
            _tripDetailRepository = tripDetailRepository;
            _mapper = mapper;
        }

        public async Task<List<TripDetailDTO>> GetAllTripDetailsWithPaging(int pageIndex, int pageSize, UserDetailDTO currentUser)
        {
            try
            {
                List<Tbltripdetail> tblplanlocations = await _tripDetailRepository.GetAllTripDetailsWithPaging(pageIndex, pageSize);
                // convert entity to dto
                List<TripDetailDTO> planLocations = _mapper.Map<List<TripDetailDTO>>(tblplanlocations);
                return planLocations;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<TripDetailDTO> GetTripDetailById(string locationId)
        {
            try
            {
                Tbltripdetail tbltripdetail = await _tripDetailRepository.GetTripDetailById(locationId);
                if (tbltripdetail == null)
                    throw new NotFoundException("No DailyReport Object Found!!!");
                // convert entity to dto
                TripDetailDTO tripDetailDTO = _mapper.Map<TripDetailDTO>(tbltripdetail);
                return tripDetailDTO;
            }
            catch (Exception e)
            {
                //LoggerService.Logger(e.ToString());
                throw new Exception(e.Message);
            }
        }
        public async Task<string> CreateTripDetail(TripDetailDTO tripDetailDTO)
        {
            try
            {
                // convert dto to entity
                Tbltripdetail tbltripdetai = _mapper.Map<Tbltripdetail>(tripDetailDTO);
                int id = await _tripDetailRepository.CreateTripDetail(tbltripdetai);
                if (id > 0)
                {
                    return "Ok";
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

        public async Task<string> UpdateTripDetail(TripDetailDTO tripDetailDTO)
        {
            try
            {
                // convert dto to entity
                Tbltripdetail tbltripdetai = _mapper.Map<Tbltripdetail>(tripDetailDTO);
                int id = await _tripDetailRepository.UpdateTripDetail(tbltripdetai);
                if (id > 0)
                {
                    return "Ok";
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

        public async Task<string> DeleteTripDetail(string tripDetailId)
        {
            try
            {

                int id = await _tripDetailRepository.DeleteTripDetail(tripDetailId);
                if (id > 0)
                {
                    return "Ok";
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
    }
}
