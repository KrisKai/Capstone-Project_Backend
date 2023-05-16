using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.IRepositories
{
    public interface ITripMemberRepository
    {
        //SELECT ALL
        public Task<List<TbltripmemberVO>> GetAllTripMembersWithPaging(int pageIndex, int pageSize, string? memberName);
        //SELECT LAST ONE
        public Task<int> GetLastOneId();
        //SELECT BY ID
        public Task<TbltripmemberVO> GetTripMemberById(int tripMemberId);
        //COUNT BY USERNAME AND TRIP ID
        public Task<int> CountTripMemberByUserIdAndTripId(string userId, string tripId);
        //COUNT
        public Task<int> CountAllTripMembers(string? memberName);
        //CREATE
        public Task<int> CreateTripMember(Tbltripmember tbltripmember);
        //UPDATE
        public Task<int> UpdateTripMember(Tbltripmember tbltripmember);
        //DELETE
        public Task<int> DeleteTripMember(int tripMemberId);
        //UPDATE STATUS
        public Task<int> UpdateMemberStatus(Tbltripmember tbltripmember);
        //DELETE BY USER ID
        public Task<int> DeleteTripMemberByUserId(string userId);
        //CONFIRM INVITATION
        public Task<int> ConfirmTrip(int tripMemberId);
        public Task<int> UpdateSendMailDate(int id);
    }
}
