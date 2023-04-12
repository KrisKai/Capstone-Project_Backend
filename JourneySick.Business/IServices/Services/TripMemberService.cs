using AutoMapper;
using JourneySick.Business.Models.DTOs;
using JourneySick.Data.IRepositories;
using JourneySick.Data.IRepositories.Repositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using Microsoft.Extensions.Logging;

namespace JourneySick.Business.IServices.Services
{
    public class TripMemberService : ITripMemberService
    {
        private readonly ITripMemberRepository _tripMemberRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<TripMemberService> _logger;

        public TripMemberService(ITripMemberRepository tripMemberRepository, IMapper mapper, ILogger<TripMemberService> logger)
        {
            _tripMemberRepository = tripMemberRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public Task<List<TripMemberDTO>> GetAllTripMembersWithPaging(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<TripMemberDTO> GetTripMemberById(int memberId)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateTripMember(TripMemberDTO tripMemberDTO)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateTripMember(TripMemberDTO tripMemberDTO)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteTripMember(int memberId)
        {
            throw new NotImplementedException();
        }
    }
}
