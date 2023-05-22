using Dapper;
using Dapper.Transaction;
using JourneySick.Data.Helpers;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using Microsoft.Extensions.Configuration;
using System.Data;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace JourneySick.Data.IRepositories.Repositories
{
    public class MapLocationRepository : BaseRepository, IMapLocationRepository
    {
        public MapLocationRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<MapLocation> GetMapLocationById(int locationId)
        {
            try
            {
                var query = "SELECT * FROM map_location WHERE MapId = @MapId";

                var parameters = new DynamicParameters();
                parameters.Add("MapId", locationId, DbType.Int16);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<MapLocation>(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<List<MapLocation>> GetAllLocationsWithPaging(int pageIndex, int pageSize)
        {
            try
            {
                int firstIndex = (pageIndex - 1) * pageSize;
                int lastIndex = pageIndex * pageSize;
                var query = "SELECT * FROM map_location LIMIT @firstIndex, @lastIndex";

                var parameters = new DynamicParameters();
                parameters.Add("firstIndex", firstIndex, DbType.Int16);
                parameters.Add("lastIndex", lastIndex, DbType.Int16);

                using var connection = CreateConnection();
                return (await connection.QueryAsync<MapLocation>(query, parameters)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> GetLastOne()
        {
            try
            {
                var query = "SELECT COALESCE(MAX(MapId), 0) FROM map_location";

                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<int>(query);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<long> CreateMapLocation(MapLocation maplocation)
        {

            try
            {
                long lastId;
                var query = "INSERT INTO map_location ("
                    + "         Longitude, "
                    + "         Latitude, "
                    + "         LocationName) "
                    + "     VALUES ( "
                    + "         @Longitude, "
                    + "         @Latitude, "
                    + "         @LocationName)";

                var getLastId = "SELECT LAST_INSERT_ID()";
                

                var parameters = new DynamicParameters();
                parameters.Add("Longitude", maplocation.Longitude, DbType.String);
                parameters.Add("Latitude", maplocation.Latitude, DbType.String);
                parameters.Add("LocationName", maplocation.LocationName, DbType.String);

                
                using (var connection = CreateConnection()) {
                    connection.Open();
                    using var transaction = connection.BeginTransaction();
                    transaction.Execute(query, parameters);
                    lastId = transaction.ExecuteScalar<long>(getLastId);
                    transaction.Commit();
                }
                return lastId;
                //return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public async Task<int> UpdateMapLocation(MapLocation maplocation)
        {

            try
            {
                var query = "UPDATE map_location SET"
                    + "         Longitude = @Longitude, "
                    + "         Latitude = @Latitude, "
                    + "         LocationName = @LocationName, "
                    + "     WHERE MapId = @MapId";

                var parameters = new DynamicParameters();
                parameters.Add("MapId", maplocation.MapId, DbType.Int32);
                parameters.Add("Longitude", maplocation.Longitude, DbType.String);
                parameters.Add("Latitude", maplocation.Latitude, DbType.String);
                parameters.Add("LocationName", maplocation.LocationName, DbType.String);

                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> DeleteMapLocation(int locationId)
        {
            try
            {
                var query = "DELETE FROM map_location WHERE MapId = @MapId";

                var parameters = new DynamicParameters();
                parameters.Add("MapId", locationId, DbType.Int32);
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
