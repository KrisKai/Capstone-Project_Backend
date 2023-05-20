using AutoMapper;
using JourneySick.Data.IRepositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using Microsoft.Extensions.Logging;
using RevenueSharingInvest.Business.Exceptions;

namespace JourneySick.Business.IServices.Services
{
    public class PlanLocationService : IPlanLocationService
    {
        private readonly IPlanLocationRepository _planLocationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<PlanLocationService> _logger;
        public PlanLocationService(IPlanLocationRepository planLocationRepository, IMapper mapper, ILogger<PlanLocationService> logger)
        {
            _planLocationRepository = planLocationRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<PlanLocationDTO>> GetAllLocationsWithPaging(int pageIndex, int pageSize)
        {
            try
            {
                List<PlanLocation> planlocations = await _planLocationRepository.GetAllLocationsWithPaging(pageIndex, pageSize);
                // convert entity to dto
                List<PlanLocationDTO> planLocations = _mapper.Map<List<PlanLocationDTO>>(planlocations);
                return planLocations;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }
    

        public async Task<PlanLocationDTO> GetPlanLocationById(int locationId)
        {
            try
            {
                PlanLocation planlocation = await _planLocationRepository.GetPlanLocationById(locationId);
                if (planlocation == null)
                    throw new NotFoundException("No DailyReport Object Found!!!");
                // convert entity to dto
                PlanLocationDTO planLocationDTO = _mapper.Map<PlanLocationDTO>(planlocation);
                return planLocationDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }
        public async Task<string> CreatePlanLocation(PlanLocationDTO planLocationDTO)
        {
            try
            {
                // convert dto to entity
                PlanLocation planlocation = _mapper.Map<PlanLocation>(planLocationDTO);
                int id = await _planLocationRepository.CreatePlanLocation(planlocation);
                if(id > 0) 
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
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<string> UpdatePlanLocation(PlanLocationDTO planLocationDTO)
        {
            try
            {
                // convert dto to entity
                PlanLocation planlocation = _mapper.Map<PlanLocation>(planLocationDTO);
                int id = await _planLocationRepository.UpdatePlanLocation(planlocation);
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
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<string> DeletePlanLocation(int locationId)
        {
            try
            {

                int id = await _planLocationRepository.DeletePlanLocation(locationId);
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
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }
    }
}
