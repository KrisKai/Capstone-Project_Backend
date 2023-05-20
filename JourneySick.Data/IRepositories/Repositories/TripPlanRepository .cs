using Dapper;
using JourneySick.Data.Helpers;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;
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

        public async Task<List<TripPlan>> GetAllTripPlansWithPaging(int pageIndex, int pageSize, string? planId)
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

                var query = "SELECT * FROM tripplan WHERE PlanId LIKE CONCAT('%', @planId, '%')  LIMIT @firstIndex, @lastIndex";

                using var connection = CreateConnection();
                return (await connection.QueryAsync<TripPlan>(query, parameters)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<TripPlan> GetTripPlanById(int tripPlanId)
        {
            try
            {
                var query = "SELECT * FROM tripplan WHERE PlanId = @PlanId";

                var parameters = new DynamicParameters();
                parameters.Add("PlanId", tripPlanId, DbType.Int16);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<TripPlan>(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> CountAllTripPlans(string? planId)
        {
            try
            {
                var query = "SELECT COUNT(*) FROM tripplan WHERE PlanId LIKE CONCAT('%', @planId, '%')";

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

        public async Task<int> CreateTripPlan(TripPlan tripplan)
        {
            try
            {
                var query = "INSERT INTO tripplan ("
                    + "         TripId, "
                    + "         PlanDescription, "
                    + "         CreateDate, "
                    + "         CreateBy) "
                    + "     VALUES ( "
                    + "         @TripId, "
                    + "         @PlanDescription, "
                    + "         @CreateDate, "
                    + "         @CreateBy)";

                var parameters = new DynamicParameters();
                parameters.Add("PlanId", tripplan.PlanId, DbType.String);
                parameters.Add("TripId", tripplan.TripId, DbType.String);
                parameters.Add("PlanDescription", tripplan.PlanDescription, DbType.String);
                parameters.Add("CreateDate", tripplan.CreateDate, DbType.DateTime);
                parameters.Add("CreateBy", tripplan.CreateBy, DbType.String);

                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public async Task<int> UpdateTripPlan(TripPlan tripplan)
        {
            try
            {
                var query = "UPDATE tripplan SET " +
                    "PlanDescription = @PlanDescription, " +
                    "UpdateDate = @UpdateDate, " +
                    "UpdateBy = @UpdateBy " +
                    "WHERE PlanId = @PlanId";

                var parameters = new DynamicParameters();
                parameters.Add("PlanId", tripplan.PlanId, DbType.String);
                parameters.Add("PlanDescription", tripplan.PlanDescription, DbType.String);
                parameters.Add("UpdateDate ", tripplan.UpdateDate, DbType.DateTime);
                parameters.Add("UpdateBy", tripplan.UpdateBy, DbType.String);
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> DeleteTripPlan(int tripPlanId)
        {
            try
            {
                var query = "DELETE FROM tripplan WHERE PlanId = @PlanId";

                var parameters = new DynamicParameters();
                parameters.Add("PlanId", tripPlanId, DbType.String);
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }


    }
}
