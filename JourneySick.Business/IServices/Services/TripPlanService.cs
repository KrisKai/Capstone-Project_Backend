using AutoMapper;
using JourneySick.Business.Helpers;
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
    public class TripPlanService : ITripPlanService
    {
        private readonly ITripPlanRepository _tripPlanRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<TripPlanService> _logger;
        public TripPlanService(ITripPlanRepository tripPlanRepository, IMapper mapper, ILogger<TripPlanService> logger)
        {
            _tripPlanRepository = tripPlanRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<AllTripPlanDTO> GetAllTripPlansWithPaging(int pageIndex, int pageSize, string? planId)
        {
            AllTripPlanDTO result = new();
            try
            {
                List<Tbltripplan> tbltrips = await _tripPlanRepository.GetAllTripPlansWithPaging(pageIndex, pageSize, planId);
                // convert entity to dto
                List<TripPlanDTO> trips = _mapper.Map<List<TripPlanDTO>>(tbltrips);
                int count = await _tripPlanRepository.CountAllTripPlans(planId);
                result.ListOfPlan = trips;
                result.NumOfPlan = count;
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<TripPlanDTO> GetTripPlanById(int planId)
        {
            try
            {
                Tbltripplan tbltripplan = await _tripPlanRepository.GetTripPlanById(planId);
                // convert entity to dto
                TripPlanDTO tripPlanDTO = _mapper.Map<TripPlanDTO>(tbltripplan);

                return tripPlanDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<int> CreateTripPlan(TripPlanDTO tripPlanDTO, CurrentUserObj currentUser)
        {
            try
            {
                tripPlanDTO.FldCreateBy = currentUser.UserId;
                tripPlanDTO.FldCreateDate = DateTimePicker.GetDateTimeByTimeZone();
                Tbltripplan tbltripplan = _mapper.Map<Tbltripplan>(tripPlanDTO);
                int id = await _tripPlanRepository.CreateTripPlan(tbltripplan);
                if (id > 0)
                {
                    return id;
                }
                throw new InsertException("Create trip plan failed!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<int> UpdateTripPlan(TripPlanDTO tripPlanDTO, CurrentUserObj currentUser)
        {
            try
            {
                TripPlanDTO getTrip = await GetTripPlanById((int)tripPlanDTO.FldPlanId);

                if (getTrip != null)
                {
                    tripPlanDTO.FldUpdateBy = currentUser.UserId;
                    tripPlanDTO.FldUpdateDate = DateTimePicker.GetDateTimeByTimeZone();
                    Tbltripplan tbltripplan = _mapper.Map<Tbltripplan>(tripPlanDTO);
                    if (await _tripPlanRepository.UpdateTripPlan(tbltripplan) > 0)
                    {
                        return (int)tripPlanDTO.FldPlanId;
                    }
                    else
                    {
                        throw new UpdateException("Update trip plan failed!");
                    }
                }
                else
                {
                    throw new GetOneException("Trip plan is not existed!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<int> DeleteTripPlan(int planId)
        {
            try
            {
                TripPlanDTO getTrip = await GetTripPlanById(planId);

                if (getTrip != null)
                {
                    if (await _tripPlanRepository.DeleteTripPlan(planId) > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        throw new DeleteException("Delete trip plan failed!");
                    }

                }
                else
                {
                    throw new GetOneException("Trip plan is not existed!");
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
