using Dapper;
using JourneySick.Data.Helpers;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace JourneySick.Data.IRepositories.Repositories
{
    public class TripRouteRepository : BaseRepository, ITripRouteRepository
    {
        public TripRouteRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<TbltriprouteVO>> GetAllTripRoutesWithPaging(int pageIndex, int pageSize, string? routeId)
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

                var query = "SELECT * FROM tbltriproute a INNER JOIN tblmaplocation b ON a.fldMapId = b.fldMapId WHERE fldRouteId LIKE CONCAT('%', @routeId, '%')  LIMIT @firstIndex, @lastIndex";

                using var connection = CreateConnection();
                return (await connection.QueryAsync<TbltriprouteVO>(query, parameters)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<Tbltriproute> GetTripRouteById(int tripRouteId)
        {
            try
            {
                var query = "SELECT * FROM tbltriproute WHERE fldRouteId = @fldRouteId";

                var parameters = new DynamicParameters();
                parameters.Add("fldRouteId", tripRouteId, DbType.Int16);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<Tbltriproute>(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> CountAllTripRoutes(string? routeId)
        {
            try
            {
                var query = "SELECT COUNT(*) FROM tbltriproute WHERE fldRouteId LIKE CONCAT('%', @routeId, '%')";

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

        public async Task<int> CreateTripRoute(Tbltriproute tbltriproute)
        {
            try
            {
                var query = "INSERT INTO tbltriproute ("
                    + "         fldTripId, "
                    + "         fldMapId, "
                    + "         fldPriority, "
                    + "         fldEstimateTime, "
                    + "         fldDistance) "
                    + "     VALUES ( "
                    + "         @fldTripId, "
                    + "         @fldMapId, "
                    + "         @fldPriority, "
                    + "         @fldEstimateTime, "
                    + "         @fldDistance)";

                var parameters = new DynamicParameters();
                parameters.Add("fldTripId", tbltriproute.FldTripid, DbType.String);
                parameters.Add("fldMapId", tbltriproute.FldMapId, DbType.Int32);
                parameters.Add("fldPriority", tbltriproute.FldPriority, DbType.Int32);
                parameters.Add("fldEstimateTime", tbltriproute.FldEstimateTime, DbType.Decimal);
                parameters.Add("fldDistance", tbltriproute.FldDistance, DbType.Decimal);

                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public async Task<int> UpdateTripRoute(Tbltriproute tbltriproute)
        {
            try
            {
                var query = "UPDATE tbltriproute SET " +
                    "fldPriority = @fldPriority, " +
                    "fldEstimateTime = @fldEstimateTime, " +
                    "fldDistance = @fldDistance, " +
                    "WHERE fldRouteId = @fldRouteId";

                var parameters = new DynamicParameters();
                parameters.Add("fldRouteId", tbltriproute.FldRouteId, DbType.String);
                parameters.Add("fldPriority", tbltriproute.FldPriority, DbType.Int32);
                parameters.Add("fldEstimateTime", tbltriproute.FldEstimateTime, DbType.Decimal);
                parameters.Add("fldDistance", tbltriproute.FldDistance, DbType.Decimal);
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> DeleteTripRoute(int tripRouteId)
        {
            try
            {
                var query = "DELETE FROM tbltriproute WHERE fldRouteId = @fldRouteId";

                var parameters = new DynamicParameters();
                parameters.Add("fldRouteId", tripRouteId, DbType.String);
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
