using AutoMapper;
using JourneySick.Data.IRepositories;
using JourneySick.Data.IRepositories.Repositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.VO;

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

        public Task<string> CreateTripMember(TripMemberDTO tripMemberDTO)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteTripMember(string memberId)
        {
            throw new NotImplementedException();
        }

        public Task<List<TripMemberDTO>> GetAllTripMembersWithPaging(int pageIndex, int pageSize, UserDetailDTO currentUser)
        {
            throw new NotImplementedException();
        }

        public Task<TripMemberDTO> GetTripMember(string memberId)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateTripMember(TripMemberDTO tripMemberDTO)
        {
            throw new NotImplementedException();
        }
    }
}
