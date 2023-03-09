using Dapper;
using JourneySick.Data.Helpers;
using JourneySick.Data.Models.Entities;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace JourneySick.Data.IRepositories.Repositories
{
    public class TripMemberRepository : BaseRepository, ITripMemberRepository
    {
        public TripMemberRepository(IConfiguration configuration) : base(configuration)
        {
        }


        public Task<int> GetLastOneId()
        {
            throw new NotImplementedException();
        }

        public Task<Tbltripmember> GetTripMemberById(int planDetailId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Tbltripmember>> GetAllTripMembersWithPaging(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateTripMember(Tbltripmember tbltripmember)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateTripMember(Tbltripmember tbltripmember)
        {
            throw new NotImplementedException();
        }


        public Task<int> DeleteTripMember(int planDetailId)
        {
            throw new NotImplementedException();
        }
    }
}
