using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.Request;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;

namespace JourneySick.Business.IServices
{
    public interface ITripMemberService
    {
        //Select list w paging
        public Task<AllTripMemberDTO> GetAllTripMembersWithPaging(int pageIndex, int pageSize, string? memberName);
        //Select
        public Task<TripMemberRequest> GetTripMemberById(int memberId);
        //insert
        public Task<int> CreateTripMember(TripMemberDTO tripMemberDTO, CurrentUserRequest currentUser);
        //update
        public Task<int> UpdateTripMember(TripMemberDTO tripMemberDTO, CurrentUserRequest currentUser);
        //delete
        public Task<int> DeleteTripMember(int memberId);
        //Confirm mail
        public Task<int> ConfirmTrip(int id);
        //Send mail
        public Task<int> SendMail(int id);
    }
}
