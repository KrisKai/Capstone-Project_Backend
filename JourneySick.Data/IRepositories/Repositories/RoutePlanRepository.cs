using Dapper;
using JourneySick.Data.Helpers;
using JourneySick.Data.Models.Entities;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace JourneySick.Data.IRepositories.Repositories
{
    public class RoutePlanRepository : BaseRepository, IRoutePlanRepository
    {
        public RoutePlanRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<RoutePlan>> GetAllRoutePlansWithPaging(int pageIndex, int pageSize, string? routeId)
        {
            try
            {
                int firstIndex = (pageIndex) * pageSize;
                int lastIndex = (pageIndex + 1) * pageSize;
                var parameters = new DynamicParameters();
                parameters.Add("firstIndex", firstIndex, DbType.Int16);
                parameters.Add("lastIndex", lastIndex, DbType.Int16);
                routeId ??= "";
                parameters.Add("routeId", routeId, DbType.String);

                var query = "SELECT * FROM route_plan a INNER JOIN map_location b ON a.MapId = b.MapId WHERE RouteId LIKE CONCAT('%', @routeId, '%')  LIMIT @firstIndex, @lastIndex";

                using var connection = CreateConnection();
                return (await connection.QueryAsync<RoutePlan>(query, parameters)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<RoutePlan> GetRoutePlanById(int routePlanId)
        {
            try
            {
                var query = "SELECT * FROM route_plan WHERE RouteId = @RouteId";

                var parameters = new DynamicParameters();
                parameters.Add("RouteId", routePlanId, DbType.Int16);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<RoutePlan>(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> CountAllRoutePlans(string? routeId)
        {
            try
            {
                var query = "SELECT COUNT(*) FROM route_plan WHERE RouteId LIKE CONCAT('%', @routeId, '%')";

                routeId ??= "";
                var parameters = new DynamicParameters();
                parameters.Add("routeId", routeId, DbType.String);
                using var connection = CreateConnection();
                return ((int)(long)connection.ExecuteScalar(query, parameters));

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> CreateRoutePlan(RoutePlan routeplan)
        {
            try
            {
                var query = "INSERT INTO route_plan ("
                    + "         RouteId, "
                    + "         PlanDescription) "
                    + "     VALUES ( "
                    + "         @RouteId, "
                    + "         @PlanDescription)";

                var parameters = new DynamicParameters();
                parameters.Add("RouteId", routeplan.RouteId, DbType.Int32);
                parameters.Add("PlanDescription", routeplan.PlanDescription, DbType.String);

                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public async Task<int> UpdateRoutePlan(RoutePlan routeplan)
        {
            try
            {
                var query = "UPDATE route_plan SET " +
                    "PlanDescription = @PlanDescription, " +
                    "WHERE PlanId = @PlanId";

                var parameters = new DynamicParameters();
                parameters.Add("PlanId", routeplan.PlanId, DbType.Int32);
                parameters.Add("PlanDescription", routeplan.PlanDescription, DbType.String);
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> DeleteRoutePlan(int routePlanId)
        {
            try
            {
                var query = "DELETE FROM route_plan WHERE RouteId = @RouteId";

                var parameters = new DynamicParameters();
                parameters.Add("RouteId", routePlanId, DbType.String);
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
