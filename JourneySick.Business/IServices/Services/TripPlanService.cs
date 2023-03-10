using AutoMapper;
using JourneySick.Data.IRepositories;
using JourneySick.Data.IRepositories.Repositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.VO;

namespace JourneySick.Business.IServices.Services
{
    public class TripPlanService : ITripPlanService
    {
        private readonly ITripPlanService _tripPlanRepository;
        private readonly IMapper _mapper;
        public TripPlanService(ITripPlanService tripMemberRepository, IMapper mapper)
        {
            _tripPlanRepository = _tripPlanRepository;
            _mapper = mapper;
        }
        public Task<List<TripPlanDTO>> GetAllTripPlansWithPaging(int pageIndex, int pageSize, UserDetailDTO currentUser)
        {
            throw new NotImplementedException();
        }

        public Task<TripPlanDTO> GetTripPlanById(int planId)
        {
            throw new NotImplementedException();
        }

        public Task<string> CreateTripPlan(TripPlanDTO tripPlanDTO)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateTripPlan(TripPlanDTO tripPlanDTO)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteTripPlan(int planId)
        {
            throw new NotImplementedException();
        }

    }
}
