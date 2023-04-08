using AutoMapper;
using JourneySick.Business.Models.DTOs;
using JourneySick.Data.IRepositories;
using JourneySick.Data.IRepositories.Repositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;

namespace JourneySick.Business.IServices.Services
{
    public class TripMemberService : ITripMemberService
    {
        private readonly ITripMemberRepository _tripMemberRepository;
        private readonly IMapper _mapper;

        public TripMemberService(ITripMemberRepository tripMemberRepository, IMapper mapper)
        {
            _tripMemberRepository = tripMemberRepository;
            _mapper = mapper;
        }

        public Task<List<TripMemberDTO>> GetAllTripMembersWithPaging(int pageIndex, int pageSize, CurrentUserObj currentUser)
        {
            throw new NotImplementedException();
        }

        public Task<TripMemberDTO> GetTripMemberById(int memberId)
        {
            throw new NotImplementedException();
        }

        public Task<string> CreateTripMember(TripMemberDTO tripMemberDTO)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateTripMember(TripMemberDTO tripMemberDTO)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteTripMember(int memberId)
        {
            throw new NotImplementedException();
        }
    }
}
