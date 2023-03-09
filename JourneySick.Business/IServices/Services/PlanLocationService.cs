using AutoMapper;
using JourneySick.Data.IRepositories;
using JourneySick.Data.IRepositories.Repositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.VO;

namespace JourneySick.Business.IServices.Services
{
    public class PlanLocationService : IPlanLocationService
    {
        private readonly IPlanLocationRepository _planLocationPlanRepository;
        private readonly IMapper _mapper;

        public Task<string> CreatePlanLocation(PlanLocationDTO planLocationDTO)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeletePlanLocation(string locationId)
        {
            throw new NotImplementedException();
        }

        public Task<List<PlanLocationDTO>> GetAllLocationsWithPaging(int pageIndex, int pageSize, UserDetailDTO currentUser)
        {
            throw new NotImplementedException();
        }

        public Task<PlanLocationDTO> GetPlanLocation(string locationId)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdatePlanLocation(PlanLocationDTO planLocationDTO)
        {
            throw new NotImplementedException();
        }
    }
}
