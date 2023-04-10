using AutoMapper;
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
        public TripPlanService(ITripPlanRepository tripPlanRepository, IMapper mapper)
        {
            _tripPlanRepository = tripPlanRepository;
            _mapper = mapper;
        }
        public async Task<AllTripPlanDTO> GetAllTripPlansWithPaging(int pageIndex, int pageSize, string? planId, CurrentUserObj currentUser)
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
                result.CurrentUserObj = currentUser;
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
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
