using AutoMapper;
using JourneySick.Data.IRepositories;
using JourneySick.Data.IRepositories.Repositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.VO;
using MySqlX.XDevAPI.Common;
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

        public Task<List<PlanLocationDTO>> GetAllLocationsWithPaging(int pageIndex, int pageSize, UserDetailDTO currentUser)
        {
            throw new NotImplementedException();
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
                // convert entity to dto
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

        public async Task<string> DeletePlanLocation(int locationId, UserDetailDTO currentUser)
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
