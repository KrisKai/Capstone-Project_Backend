using Dapper;
using JourneySick.Data.Helpers;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;
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

        public Task<int> DeleteTripPlan(int tripPlanId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetLastOneId()
        {
            try
            {
                var query = "SELECT COALESCE(MAX(fldPlanId), 0) FROM tbltripplan ";
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<int>(query);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<List<Tbltripplan>> GetAllTripPlansWithPaging(int pageIndex, int pageSize, string? planId)
        {
            try
            {
                int firstIndex = (pageIndex) * pageSize;
                int lastIndex = (pageIndex + 1) * pageSize;
                var parameters = new DynamicParameters();
                parameters.Add("firstIndex", firstIndex, DbType.Int16);
                parameters.Add("lastIndex", lastIndex, DbType.Int16);
                planId ??= "";
                parameters.Add("planId", planId, DbType.String);

                var query = "SELECT * FROM tbltripplan WHERE fldPlanId LIKE CONCAT('%', @planId, '%')  LIMIT @firstIndex, @lastIndex";

                using var connection = CreateConnection();
                return (await connection.QueryAsync<Tbltripplan>(query, parameters)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<Tbltripplan> SelectTripPlan(int tripPlanId)
        {
            try
            {
                var query = "SELECT * FROM tbltripplan WHERE fldPlanId = @fldPlanId";

                var parameters = new DynamicParameters();
                parameters.Add("fldPlanId", tripPlanId, DbType.Int16);
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

        public async Task<int> CountAllTripPlans(string? planId)
        {
            try
            {
                var query = "SELECT COUNT(*) FROM tbltripplan WHERE fldPlanId LIKE CONCAT('%', @planId, '%')";

                planId ??= "";
                var parameters = new DynamicParameters();
                parameters.Add("planId", planId, DbType.String);
                using var connection = CreateConnection();
                return ((int)(long)connection.ExecuteScalar(query, parameters));

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}
