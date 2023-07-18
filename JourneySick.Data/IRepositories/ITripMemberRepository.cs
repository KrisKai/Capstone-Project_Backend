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
        public Task<List<TripmemberVO>> GetAllTripMembersWithPaging(int pageIndex, int pageSize, string tripId, string? memberName);
        //SELECT BY ID
        public Task<TripmemberVO> GetTripMemberById(int tripMemberId);
        //COUNT BY USERNAME AND TRIP ID
        public Task<int> CountTripMemberByUserIdAndTripId(string userId, string tripId);
        //COUNT
        public Task<int> CountAllTripMembers(string tripId, string? memberName);
        //CREATE
        public Task<long> CreateTripMember(TripMember tripmember);
        //UPDATE
        public Task<int> UpdateTripMember(TripMember tripmember);
        //DELETE
        public Task<int> DeleteTripMember(int tripMemberId);
        //UPDATE STATUS
        public Task<int> UpdateMemberStatus(TripMember tripmember);
        //DELETE BY user ID
        public Task<int> DeleteTripMemberByUserId(string userId);
        //DELETE BY TRIP ID
        public Task<int> DeleteTripMemberByTripId(string tripId);
        //CONFIRM INVITATION
        public Task<int> ConfirmTrip(int tripMemberId);
        public Task<int> UpdateSendMailDate(int id);
    }
}
