using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
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
        public Task<List<Tbltripmember>> GetAllTripMembersWithPaging(int pageIndex, int pageSize);
        public Task<int> GetLastOneId();
        public Task<Tbltripmember> GetTripMemberById(int planDetailId);
        //CREATE
        public Task<int> CreateTripMember(Tbltripmember tbltripmember);
        //UPDATE
        public Task<int> UpdateTripMember(Tbltripmember tbltripmember);
        //DELETE
        public Task<int> DeleteTripMember(int planDetailId);

    }
}
