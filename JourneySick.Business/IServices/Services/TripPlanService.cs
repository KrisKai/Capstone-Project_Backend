using AutoMapper;
using JourneySick.Business.Models.DTOs;
using JourneySick.Data.IRepositories;
using JourneySick.Data.IRepositories.Repositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;

namespace JourneySick.Business.IServices.Services
{
    public class TripPlanService : ITripPlanService
    {
        private readonly ITripPlanRepository _tripPlanRepository;
        private readonly IMapper _mapper;
        public TripPlanService(ITripPlanRepository tripPlanRepository, IMapper mapper)
        {
            _tripPlanRepository = tripPlanRepository;
            _mapper = mapper;
        }
        public Task<List<TripPlanDTO>> GetAllTripPlansWithPaging(int pageIndex, int pageSize, CurrentUserObj currentUser)
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
