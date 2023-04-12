using AutoMapper;
using JourneySick.Business.Models.DTOs;
using JourneySick.Data.IRepositories;
using JourneySick.Data.IRepositories.Repositories;
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
                List<Tblplanlocation> tblplanlocations = await _planLocationRepository.GetAllLocationsWithPaging(pageIndex, pageSize);
                // convert entity to dto
                List<PlanLocationDTO> planLocations = _mapper.Map<List<PlanLocationDTO>>(tblplanlocations);
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
                Tblplanlocation tblplanlocation = await _planLocationRepository.GetPlanLocationById(locationId);
                if (tblplanlocation == null)
                    throw new NotFoundException("No DailyReport Object Found!!!");
                // convert entity to dto
                PlanLocationDTO planLocationDTO = _mapper.Map<PlanLocationDTO>(tblplanlocation);
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
                Tblplanlocation tblplanlocation = _mapper.Map<Tblplanlocation>(planLocationDTO);
                int id = await _planLocationRepository.CreatePlanLocation(tblplanlocation);
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
                Tblplanlocation tblplanlocation = _mapper.Map<Tblplanlocation>(planLocationDTO);
                int id = await _planLocationRepository.UpdatePlanLocation(tblplanlocation);
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
