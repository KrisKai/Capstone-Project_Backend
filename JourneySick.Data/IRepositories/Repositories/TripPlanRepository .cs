using Dapper;
using JourneySick.Data.Helpers;
using JourneySick.Data.Models.Entities;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace JourneySick.Data.IRepositories.Repositories
{
    public class TripPlanRepository : BaseRepository, ITripPlanRepository
    {
        public TripPlanRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public Task<int> CreateTripPlan(Tbltripplan tbltripplan)
        {
            throw new NotImplementedException();
        }


        public async Task<string> GetLastOneId()
        {
            try
            {
                var query = "SELECT MAX(fldPlanId) FROM tbltripplan ";
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<string>(query);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }


        public async Task<Tbltripplan> SelectTripPlan(string tripPlanId)
        {
            try
            {
                var query = "SELECT * FROM tbltripplan WHERE fldPlanId = @fldPlanId";

                var parameters = new DynamicParameters();
                parameters.Add("fldPlanId", tripPlanId, DbType.String);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<Tbltripplan>(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

       
        public async Task<int> UpdateTripPlan(Tbltripplan tbltripplan)
        {
            throw new NotImplementedException();
        }

    }
}
