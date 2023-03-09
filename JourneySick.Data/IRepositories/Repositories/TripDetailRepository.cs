using Dapper;
using JourneySick.Data.Helpers;
using JourneySick.Data.Models.Entities;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace JourneySick.Data.IRepositories.Repositories
{
    public class TripDetailRepository : BaseRepository, ITripDetailRepository
    {
        public TripDetailRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public Task<int> GetLastOneId()
        {
            throw new NotImplementedException();
        }

        public Task<Tbltripdetail> GetTripDetailById(int planDetailId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Tbltripdetail>> GetAllTripDetailsWithPaging(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
        public Task<int> CreateTripDetail(Tbltripdetail tbltripdetail)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateTripDetail(Tbltripdetail tbltripdetail)
        {
            throw new NotImplementedException();
        }
        public Task<int> DeleteTripDetail(int planDetailId)
        {
            throw new NotImplementedException();
        }
    }
}
