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

        public Task<string> CreateTripPlan(TripPlanDTO tripPlanDTO)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteTripPlan(string planId)
        {
            throw new NotImplementedException();
        }

        public Task<List<TripPlanDTO>> SelectAllTripPlanWithPaging()
        {
            throw new NotImplementedException();
        }

        public Task<TripPlanDTO> SelectTripPlan(string planId)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateTripPlan(TripPlanDTO tripPlanDTO)
        {
            throw new NotImplementedException();
        }
    }
}
