using Dapper;
using JourneySick.Data.Helpers;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace JourneySick.Data.IRepositories.Repositories
{
    public class RoutePlanRepository : BaseRepository, IRoutePlanRepository
    {
        public RoutePlanRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<Tblrouteplan>> GetAllRoutePlansWithPaging(int pageIndex, int pageSize, string? routeId)
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

                var query = "SELECT * FROM tblrouteplan a INNER JOIN tblmaplocation b ON a.fldMapId = b.fldMapId WHERE fldRouteId LIKE CONCAT('%', @routeId, '%')  LIMIT @firstIndex, @lastIndex";

                using var connection = CreateConnection();
                return (await connection.QueryAsync<Tblrouteplan>(query, parameters)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<Tblrouteplan> GetRoutePlanById(int routePlanId)
        {
            try
            {
                var query = "SELECT * FROM tblrouteplan WHERE fldRouteId = @fldRouteId";

                var parameters = new DynamicParameters();
                parameters.Add("fldRouteId", routePlanId, DbType.Int16);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<Tblrouteplan>(query, parameters);
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
                var query = "SELECT COUNT(*) FROM tblrouteplan WHERE fldRouteId LIKE CONCAT('%', @routeId, '%')";

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

        public async Task<int> CreateRoutePlan(Tblrouteplan tblrouteplan)
        {
            try
            {
                var query = "INSERT INTO tblrouteplan ("
                    + "         fldRouteId, "
                    + "         fldPlanDescription) "
                    + "     VALUES ( "
                    + "         @fldRouteId, "
                    + "         @fldPlanDescription)";

                var parameters = new DynamicParameters();
                parameters.Add("fldRouteId", tblrouteplan.FldRouteId, DbType.Int32);
                parameters.Add("fldPlanDescription", tblrouteplan.FldPlanDescription, DbType.String);

                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public async Task<int> UpdateRoutePlan(Tblrouteplan tblrouteplan)
        {
            try
            {
                var query = "UPDATE tblrouteplan SET " +
                    "fldPlanDescription = @fldPlanDescription, " +
                    "WHERE fldPlanId = @fldPlanId";

                var parameters = new DynamicParameters();
                parameters.Add("fldPlanId", tblrouteplan.FldPlanId, DbType.Int32);
                parameters.Add("fldPlanDescription", tblrouteplan.FldPlanDescription, DbType.String);
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
                var query = "DELETE FROM tblrouteplan WHERE fldRouteId = @fldRouteId";

                var parameters = new DynamicParameters();
                parameters.Add("fldRouteId", routePlanId, DbType.String);
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
