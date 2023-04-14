using JourneySick.Business.Models.DTOs;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;

namespace JourneySick.Business.IServices
{
    public interface ITripMemberService
    {
        //Select list w paging
        public Task<AllTripMemberDTO> GetAllTripMembersWithPaging(int pageIndex, int pageSize, string? memberName);
        //Select Location
        public Task<TripMemberDTO> GetTripMemberById(int memberId);
        //insert
        public Task<int> CreateTripMember(TripMemberDTO tripMemberDTO, CurrentUserObj currentUser);
        //update
        public Task<int> UpdateTripMember(TripMemberDTO tripMemberDTO, CurrentUserObj currentUser);
        //update
        public Task<int> DeleteTripMember(int memberId);

    }
}
