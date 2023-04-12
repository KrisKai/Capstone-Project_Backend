using JourneySick.Business.Models.DTOs;
using JourneySick.Data.Models.DTOs;

namespace JourneySick.Business.IServices
{
    public interface ITripMemberService
    {
        //Select list w paging
        public Task<List<TripMemberDTO>> GetAllTripMembersWithPaging(int pageIndex, int pageSize);
        //Select Location
        public Task<TripMemberDTO> GetTripMemberById(int memberId);
        //insert
        public Task<String> CreateTripMember(TripMemberDTO tripMemberDTO);
        //update
        public Task<String> UpdateTripMember(TripMemberDTO tripMemberDTO);
        //update
        public Task<String> DeleteTripMember(int memberId);

    }
}
