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
        public Task<int> GetLastOneId();
        public Task<TbltripmemberVO> GetTripMemberById(int planDetailId);
        public Task<int> CountAllTripMembers(string? memberName);
        //CREATE
        public Task<int> CreateTripMember(Tbltripmember tbltripmember);
        //UPDATE
        public Task<int> UpdateTripMember(Tbltripmember tbltripmember);
        //DELETE
        public Task<int> DeleteTripMember(int planDetailId);

        public Task<int> UpdateMemberStatus(Tbltripmember tbltripmember);

    }
}
