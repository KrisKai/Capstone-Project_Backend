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

        public async Task<Tblplanlocation> GetPlanLocationById(int locationId)
        {
            try
            {
                var query = "SELECT * FROM tblplanlocation WHERE fldPlanId = @fldPlanId";

                var parameters = new DynamicParameters();
                parameters.Add("fldPlanId", locationId, DbType.Int16);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<Tblplanlocation>(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<List<Tblplanlocation>> GetAllLocationsWithPaging(int pageIndex, int pageSize)
        {
            try
            {
                int firstIndex = (pageIndex - 1) * pageSize;
                int lastIndex = pageIndex * pageSize;
                var query = "SELECT * FROM tblplanlocation LIMIT @firstIndex, @lastIndex";

                var parameters = new DynamicParameters();
                parameters.Add("firstIndex", firstIndex, DbType.Int16);
                parameters.Add("lastIndex", lastIndex, DbType.Int16);

                using var connection = CreateConnection();
                return (await connection.QueryAsync<Tblplanlocation>(query, parameters)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> CreatePlanLocation(Tblplanlocation tblplanlocation)
        {

            try
            {
                var query = "INSERT INTO tblplanlocation ("
                    + "         fldPlanId, "
                    + "         fldMapId, "
                    + "         fldPlanLocationId, "
                    + "         fldPlanLocationDescription, "
                    + "         fldLocationArrivalTime, "
                    + "         fldCreateDate, "
                    + "         fldCreateBy, "
                    + "         fldUpdateDate, "
                    + "         fldUpdateBy) "
                    + "     VALUES ( "
                    + "         @fldPlanId, "
                    + "         @fldMapId, "
                    + "         @fldPlanLocationId, "
                    + "         @fldPlanLocationDescription, "
                    + "         @fldLocationArrivalTime, "
                    + "         @fldCreateDate, "
                    + "         @fldCreateBy, "
                    + "         @fldUpdateDate, "
                    + "         @fldUpdateBy)";

                var parameters = new DynamicParameters();
                parameters.Add("fldPlanId", tblplanlocation.FldPlanId, DbType.Int16);
                parameters.Add("fldMapId", tblplanlocation.FldMapId, DbType.Int16);
                parameters.Add("fldPlanLocationId", tblplanlocation.FldPlanLocationId, DbType.String);
                parameters.Add("fldPlanLocationDescription", tblplanlocation.FldPlanLocationDescription, DbType.String);
                parameters.Add("fldLocationArrivalTime", tblplanlocation.FldLocationArrivalTime, DbType.String);
                parameters.Add("fldCreateDate", tblplanlocation.FldCreateDate, DbType.DateTime);
                parameters.Add("fldCreateBy", tblplanlocation.FldCreateBy, DbType.String);
                parameters.Add("fldUpdateDate", tblplanlocation.FldUpdateDate, DbType.DateTime);
                parameters.Add("fldUpdateBy", tblplanlocation.FldUpdateBy, DbType.String);

                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public async Task<int> UpdatePlanLocation(Tblplanlocation tblplanlocation)
        {

            try
            {
                var query = "UPDATE tblplanlocation SET"
                    + "         fldPlanLocationId = @fldPlanLocationId, "
                    + "         fldPlanLocationDescription = @fldPlanLocationDescription, "
                    + "         fldLocationArrivalTime = @fldLocationArrivalTime, "
                    + "         fldCreateDate = @fldCreateDate, "
                    + "         fldCreateBy = @fldCreateBy, "
                    + "         fldUpdateDate = @fldUpdateDate, "
                    + "         fldUpdateBy = @fldUpdateBy"
                    + "     WHERE fldPlanId = @fldPlanId";

                var parameters = new DynamicParameters();
                parameters.Add("fldPlanId", tblplanlocation.FldPlanId, DbType.Int16);
                parameters.Add("fldPlanLocationId", tblplanlocation.FldPlanLocationId, DbType.String);
                parameters.Add("fldPlanLocationDescription", tblplanlocation.FldPlanLocationDescription, DbType.String);
                parameters.Add("fldLocationArrivalTime", tblplanlocation.FldLocationArrivalTime, DbType.String);
                parameters.Add("fldCreateDate", tblplanlocation.FldCreateDate, DbType.DateTime);
                parameters.Add("fldCreateBy", tblplanlocation.FldCreateBy, DbType.String);
                parameters.Add("fldUpdateDate", tblplanlocation.FldUpdateDate, DbType.DateTime);
                parameters.Add("fldUpdateBy", tblplanlocation.FldUpdateBy, DbType.String);

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
                var query = "DELETE FROM tblplanlocation WHERE locationId = @locationId";

                var parameters = new DynamicParameters();
                parameters.Add("fldTripId", locationId, DbType.Int16);
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
