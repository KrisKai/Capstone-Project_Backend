using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.Request;

namespace JourneySick.Business.IServices
{
    public interface ITripMemberService
    {
        //Select list w paging
        public Task<AllTripMemberDTO> GetAllTripMembersWithPaging(int pageIndex, int pageSize, string tripId, string? memberName);
        //Select
        public Task<TripMemberRequest> GetTripMemberById(int memberId);
        //insert
        public Task<int> CreateTripMember(TripMemberDTO tripMemberDTO, CurrentUserObject currentUser);
        //update
        public Task<int> UpdateTripMember(TripMemberDTO tripMemberDTO, CurrentUserObject currentUser);
        //delete
        public Task<int> DeleteTripMember(int memberId);
        //Confirm mail
        public Task<int> ConfirmTrip(int id);
        //Send mail
        public Task<int> SendMail(int id);
        public Task<List<string>> GetAllTripMemberByEmailOrUsername(string memberName);
        public Task<List<TripMemberRequest>> GetAllTripMemberUser(string tripId, CurrentUserObject currentUser);
    }
}
