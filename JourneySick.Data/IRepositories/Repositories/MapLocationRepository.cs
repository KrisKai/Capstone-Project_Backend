using Dapper;
using JourneySick.Data.Helpers;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace JourneySick.Data.IRepositories.Repositories
{
    public class MapLocationRepository : BaseRepository, IMapLocationRepository
    {
        public MapLocationRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<Tblmaplocation> GetMapLocationById(int locationId)
        {
            try
            {
                var query = "SELECT * FROM tblmaplocation WHERE fldMapId = @fldMapId";

                var parameters = new DynamicParameters();
                parameters.Add("fldMapId", locationId, DbType.Int16);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<Tblmaplocation>(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<List<Tblmaplocation>> GetAllLocationsWithPaging(int pageIndex, int pageSize)
        {
            try
            {
                int firstIndex = (pageIndex - 1) * pageSize;
                int lastIndex = pageIndex * pageSize;
                var query = "SELECT * FROM tblmaplocation LIMIT @firstIndex, @lastIndex";

                var parameters = new DynamicParameters();
                parameters.Add("firstIndex", firstIndex, DbType.Int16);
                parameters.Add("lastIndex", lastIndex, DbType.Int16);

                using var connection = CreateConnection();
                return (await connection.QueryAsync<Tblmaplocation>(query, parameters)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> CreateMapLocation(Tblmaplocation tblmaplocation)
        {

            try
            {
                var query = "INSERT INTO tblmaplocation ("
                    + "         fldMapId, "
                    + "         fldLongitude, "
                    + "         fldLatitude, "
                    + "         fldLocationName) "
                    + "     VALUES ( "
                    + "         @fldMapId, "
                    + "         @fldLongitude, "
                    + "         @fldLatitude, "
                    + "         @fldLocationName)";

                var parameters = new DynamicParameters();
                parameters.Add("fldMapId", tblmaplocation.FldMapId, DbType.Int32);
                parameters.Add("fldLongitude", tblmaplocation.FldLongitude, DbType.String);
                parameters.Add("fldLatitude", tblmaplocation.FldLatitude, DbType.String);
                parameters.Add("fldLocationName", tblmaplocation.FldLocationName, DbType.String);

                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public async Task<int> UpdateMapLocation(Tblmaplocation tblmaplocation)
        {

            try
            {
                var query = "UPDATE tblmaplocation SET"
                    + "         fldLongitude = @fldLongitude, "
                    + "         fldLatitude = @fldLatitude, "
                    + "         fldLocationName = @fldLocationName, "
                    + "         fldCreateDate = @fldCreateDate, "
                    + "         fldCreateBy = @fldCreateBy, "
                    + "         fldUpdateDate = @fldUpdateDate, "
                    + "         fldUpdateBy = @fldUpdateBy"
                    + "     WHERE fldMapId = @fldMapId";

                var parameters = new DynamicParameters();
                parameters.Add("fldMapId", tblmaplocation.FldMapId, DbType.Int32);
                parameters.Add("fldLongitude", tblmaplocation.FldLongitude, DbType.String);
                parameters.Add("fldLatitude", tblmaplocation.FldLatitude, DbType.String);
                parameters.Add("fldLocationName", tblmaplocation.FldLocationName, DbType.String);

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
                var query = "DELETE FROM tblmaplocation WHERE locationId = @locationId";

                var parameters = new DynamicParameters();
                parameters.Add("fldTripId", locationId, DbType.Int32);
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
