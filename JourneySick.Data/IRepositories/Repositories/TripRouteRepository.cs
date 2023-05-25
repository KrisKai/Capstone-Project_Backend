﻿using Dapper;
using JourneySick.Data.Helpers;
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

        public async Task<List<TriprouteVO>> GetAllTripRoutesWithPaging(int pageIndex, int pageSize, string? routeId)
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

                var query = "SELECT * FROM trip_route a INNER JOIN map_location b ON a.MapId = b.MapId WHERE RouteId LIKE CONCAT('%', @routeId, '%')  LIMIT @firstIndex, @lastIndex";

                using var connection = CreateConnection();
                return (await connection.QueryAsync<TriprouteVO>(query, parameters)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<TripRoute> GetTripRouteById(int tripRouteId)
        {
            try
            {
                var query = "SELECT * FROM trip_route WHERE RouteId = @RouteId";

                var parameters = new DynamicParameters();
                parameters.Add("RouteId", tripRouteId, DbType.Int16);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<TripRoute>(query, parameters);
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
                var query = "SELECT COUNT(*) FROM trip_route WHERE RouteId LIKE CONCAT('%', @routeId, '%')";

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

        public async Task<int> CreateTripRoute(TripRoute triproute)
        {
            try
            {
                var query = "INSERT INTO trip_route ("
                    + "         TripId, "
                    + "         MapId, "
                    + "         Priority, "
                    + "         EstimateTime, "
                    + "         Distance) "
                    + "     VALUES ( "
                    + "         @TripId, "
                    + "         @MapId, "
                    + "         @Priority, "
                    + "         @EstimateTime, "
                    + "         @Distance)";

                var parameters = new DynamicParameters();
                parameters.Add("TripId", triproute.Tripid, DbType.String);
                parameters.Add("MapId", triproute.MapId, DbType.Int32);
                parameters.Add("Priority", triproute.Priority, DbType.Int32);
                parameters.Add("EstimateTime", triproute.EstimateTime, DbType.Decimal);
                parameters.Add("Distance", triproute.Distance, DbType.Decimal);

                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public async Task<int> UpdateTripRoute(TripRoute triproute)
        {
            try
            {
                var query = "UPDATE trip_route SET " +
                    "Priority = @Priority, " +
                    "EstimateTime = @EstimateTime, " +
                    "Distance = @Distance, " +
                    "WHERE RouteId = @RouteId";

                var parameters = new DynamicParameters();
                parameters.Add("RouteId", triproute.RouteId, DbType.String);
                parameters.Add("Priority", triproute.Priority, DbType.Int32);
                parameters.Add("EstimateTime", triproute.EstimateTime, DbType.Decimal);
                parameters.Add("Distance", triproute.Distance, DbType.Decimal);
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
                var query = "DELETE FROM trip_route WHERE RouteId = @RouteId";

                var parameters = new DynamicParameters();
                parameters.Add("RouteId", tripRouteId, DbType.String);
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
