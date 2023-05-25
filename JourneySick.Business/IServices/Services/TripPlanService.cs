using AutoMapper;
using JourneySick.Business.Helpers;
using JourneySick.Business.Helpers.Exceptions;
using JourneySick.Data.IRepositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.Request;
using JourneySick.Data.Models.Entities;
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
                List<TripPlan> tripPlans = await _tripPlanRepository.GetAllTripPlansWithPaging(pageIndex, pageSize, planId);
                // convert entity to dto
                List<TripPlanDTO> tripPlanDTOs = _mapper.Map<List<TripPlanDTO>>(tripPlans);
                int count = await _tripPlanRepository.CountAllTripPlans(planId);
                result.ListOfPlan = tripPlanDTOs;
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
                TripPlan tripplan = await _tripPlanRepository.GetTripPlanById(planId);
                // convert entity to dto
                TripPlanDTO tripPlanDTO = _mapper.Map<TripPlanDTO>(tripplan);

                return tripPlanDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<int> CreateTripPlan(TripPlanDTO tripPlanDTO, CurrentUserObject currentUser)
        {
            try
            {
                tripPlanDTO.CreateBy = currentUser.UserId;
                tripPlanDTO.CreateDate = DateTimePicker.GetDateTimeByTimeZone();
                TripPlan tripplan = _mapper.Map<TripPlan>(tripPlanDTO);
                int id = await _tripPlanRepository.CreateTripPlan(tripplan);
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

        public async Task<int> UpdateTripPlan(TripPlanDTO tripPlanDTO, CurrentUserObject currentUser)
        {
            try
            {
                TripPlanDTO getTrip = await GetTripPlanById((int)tripPlanDTO.PlanId);

                if (getTrip != null)
                {
                    tripPlanDTO.UpdateBy = currentUser.UserId;
                    tripPlanDTO.UpdateDate = DateTimePicker.GetDateTimeByTimeZone();
                    TripPlan tripplan = _mapper.Map<TripPlan>(tripPlanDTO);
                    if (await _tripPlanRepository.UpdateTripPlan(tripplan) > 0)
                    {
                        return (int)tripPlanDTO.PlanId;
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
