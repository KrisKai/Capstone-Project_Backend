using JourneySick.Business.Models.DTOs;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;

namespace JourneySick.Business.IServices
{
    public interface ITripMemberService
    {
        //Select list w paging
        public Task<AllTripMemberDTO> GetAllTripMembersWithPaging(int pageIndex, int pageSize, string? memberName);
        //Select
        public Task<TripMemberVO> GetTripMemberById(int memberId);
        //insert
        public Task<int> CreateTripMember(TripMemberDTO tripMemberDTO, CurrentUserObj currentUser);
        //update
        public Task<int> UpdateTripMember(TripMemberDTO tripMemberDTO, CurrentUserObj currentUser);
        //delete
        public Task<int> DeleteTripMember(int memberId);
        //Confirm mail
        public Task<int> ConfirmTrip(int id);
        //Send mail
        public Task<int> SendMail(int id);
    }
}
