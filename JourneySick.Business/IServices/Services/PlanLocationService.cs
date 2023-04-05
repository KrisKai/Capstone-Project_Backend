using AutoMapper;
using JourneySick.Business.Models.DTOs;
using JourneySick.Data.IRepositories;
using JourneySick.Data.IRepositories.Repositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using RevenueSharingInvest.Business.Exceptions;

namespace JourneySick.Business.IServices.Services
{
    public class PlanLocationService : IPlanLocationService
    {
        private readonly IPlanLocationRepository _planLocationRepository;
        private readonly IMapper _mapper;
        public PlanLocationService(IPlanLocationRepository planLocationRepository, IMapper mapper)
        {
            _planLocationRepository = planLocationRepository;
            _mapper = mapper;
        }

        public async Task<List<PlanLocationDTO>> GetAllLocationsWithPaging(int pageIndex, int pageSize, CurrentUserObj currentUser)
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
                throw new Exception();
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
            catch (Exception e)
            {
                //LoggerService.Logger(e.ToString());
                throw new Exception(e.Message);
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
                throw new Exception();
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
                throw new Exception();
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
                throw new Exception();
            }
        }
    }
}
