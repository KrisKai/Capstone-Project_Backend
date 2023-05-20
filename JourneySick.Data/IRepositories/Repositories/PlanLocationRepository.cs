using Dapper;
using JourneySick.Data.Helpers;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace JourneySick.Data.IRepositories.Repositories
{
    public class PlanLocationRepository : BaseRepository, IPlanLocationRepository
    {
        public PlanLocationRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<PlanLocation> GetPlanLocationById(int locationId)
        {
            try
            {
                var query = "SELECT * FROM planlocation WHERE PlanId = @PlanId";

                var parameters = new DynamicParameters();
                parameters.Add("PlanId", locationId, DbType.Int16);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<PlanLocation>(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<List<PlanLocation>> GetAllLocationsWithPaging(int pageIndex, int pageSize)
        {
            try
            {
                int firstIndex = (pageIndex - 1) * pageSize;
                int lastIndex = pageIndex * pageSize;
                var query = "SELECT * FROM planlocation LIMIT @firstIndex, @lastIndex";

                var parameters = new DynamicParameters();
                parameters.Add("firstIndex", firstIndex, DbType.Int16);
                parameters.Add("lastIndex", lastIndex, DbType.Int16);

                using var connection = CreateConnection();
                return (await connection.QueryAsync<PlanLocation>(query, parameters)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> CreatePlanLocation(PlanLocation planlocation)
        {

            try
            {
                var query = "INSERT INTO planlocation ("
                    + "         MapId, "
                    + "         PlanLocationId, "
                    + "         PlanLocationDescription, "
                    + "         LocationArrivalTime, "
                    + "         CreateDate, "
                    + "         CreateBy) "
                    + "     VALUES ( "
                    + "         @MapId, "
                    + "         @PlanLocationId, "
                    + "         @PlanLocationDescription, "
                    + "         @LocationArrivalTime, "
                    + "         @CreateDate, "
                    + "         @CreateBy)";

                var parameters = new DynamicParameters();
                parameters.Add("MapId", planlocation.MapId, DbType.Int32);
                parameters.Add("PlanLocationId", planlocation.PlanLocationId, DbType.String);
                parameters.Add("PlanLocationDescription", planlocation.PlanLocationDescription, DbType.String);
                parameters.Add("LocationArrivalTime", planlocation.LocationArrivalTime, DbType.String);
                parameters.Add("CreateDate", planlocation.CreateDate, DbType.DateTime);
                parameters.Add("CreateBy", planlocation.CreateBy, DbType.String);

                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public async Task<int> UpdatePlanLocation(PlanLocation planlocation)
        {

            try
            {
                var query = "UPDATE planlocation SET"
                    + "         PlanLocationId = @PlanLocationId, "
                    + "         PlanLocationDescription = @PlanLocationDescription, "
                    + "         LocationArrivalTime = @LocationArrivalTime, "
                    + "         UpdateDate = @UpdateDate, "
                    + "         UpdateBy = @UpdateBy"
                    + "     WHERE PlanId = @PlanId";

                var parameters = new DynamicParameters();
                parameters.Add("PlanId", planlocation.PlanId, DbType.Int16);
                parameters.Add("PlanLocationId", planlocation.PlanLocationId, DbType.String);
                parameters.Add("PlanLocationDescription", planlocation.PlanLocationDescription, DbType.String);
                parameters.Add("LocationArrivalTime", planlocation.LocationArrivalTime, DbType.String);
                parameters.Add("UpdateDate", planlocation.UpdateDate, DbType.DateTime);
                parameters.Add("UpdateBy", planlocation.UpdateBy, DbType.String);

                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> DeletePlanLocation(int locationId)
        {
            try
            {
                var query = "DELETE FROM planlocation WHERE locationId = @locationId";

                var parameters = new DynamicParameters();
                parameters.Add("TripId", locationId, DbType.Int16);
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
