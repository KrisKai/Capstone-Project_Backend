using Dapper;
using JourneySick.Data.Helpers;
using JourneySick.Data.Models.Entities;
using Microsoft.Extensions.Configuration;
using System.Data;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace JourneySick.Data.IRepositories.Repositories
{
    public class TripDetailRepository : BaseRepository, ITripDetailRepository
    {
        public TripDetailRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<Tbltripdetail> GetTripDetailById(string planDetailId)
        {
            try
            {
                var query = "SELECT * FROM tbltripdetail WHERE fldTripId = @fldTripId";

                var parameters = new DynamicParameters();
                parameters.Add("fldTripId", planDetailId, DbType.String);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<Tbltripdetail>(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<List<Tbltripdetail>> GetAllTripDetailsWithPaging(int pageIndex, int pageSize)
        {
            try
            {
                int firstIndex = (pageIndex - 1) * pageSize;
                int lastIndex = pageIndex * pageSize;
                var query = "SELECT * FROM tbltripdetail LIMIT @firstIndex, @lastIndex";

                var parameters = new DynamicParameters();
                parameters.Add("firstIndex", firstIndex, DbType.Int16);
                parameters.Add("lastIndex", lastIndex, DbType.Int16);

                using var connection = CreateConnection();
                return (await connection.QueryAsync<Tbltripdetail>(query, parameters)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public async Task<int> CreateTripDetail(Tbltripdetail tbltripdetail)
        {
            try
            {
                var query = "INSERT INTO tbltripdetail ("
                    + "         fldTripId, "
                    + "         fldTripType, "
                    + "         fldTripStartLocationName, "
                    + "         fldTripStartLocationAddress, "
                    + "         fldTripDestinationLocationName, "
                    + "         fldTripDestinationLocationAddress, "
                    + "         fldCreateDate, "
                    + "         fldCreateBy) "
                    + "     VALUES ( "
                    + "         @fldTripId, "
                    + "         @fldTripType, "
                    + "         @fldTripStartLocationName, "
                    + "         @fldTripStartLocationAddress, "
                    + "         @fldTripDestinationLocationName, "
                    + "         @fldTripDestinationLocationAddress, "
                    + "         @fldCreateDate, "
                    + "         @fldCreateBy)";

                var parameters = new DynamicParameters();
                parameters.Add("fldTripId", tbltripdetail.FldTripId, DbType.String);
                parameters.Add("fldTripType", tbltripdetail.FldTripType, DbType.String);
                parameters.Add("fldTripStartLocationName", tbltripdetail.FldTripStartLocationName, DbType.String);
                parameters.Add("fldTripStartLocationAddress", tbltripdetail.FldTripStartLocationAddress, DbType.String);
                parameters.Add("fldTripDestinationLocationName", tbltripdetail.FldTripDestinationLocationName, DbType.String);
                parameters.Add("fldTripDestinationLocationAddress", tbltripdetail.FldTripDestinationLocationAddress, DbType.String);
                parameters.Add("fldCreateDate", tbltripdetail.FldCreateDate, DbType.DateTime);
                parameters.Add("fldCreateBy", tbltripdetail.FldCreateBy, DbType.String);

                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> UpdateTripDetail(Tbltripdetail tbltripdetail)
        {
            try
            {
                var query = "UPDATE tbltripdetail SET"
                    + "         fldTripId = @fldTripId, "
                    + "         fldTripType = @fldTripType, "
                    + "         fldTripStartLocationName = @fldTripStartLocationName, "
                    + "         fldTripStartLocationAddress = @fldTripStartLocationAddress, "
                    + "         fldTripDestinationLocationName = @fldTripDestinationLocationName, "
                    + "         fldTripDestinationLocationAddress = @fldTripDestinationLocationAddress, "
                    + "         fldUpdateDate = @fldUpdateDate, "
                    + "         fldUpdateBy = @fldUpdateBy";

                var parameters = new DynamicParameters();
                parameters.Add("fldTripId", tbltripdetail.FldTripId, DbType.String);
                parameters.Add("fldTripType", tbltripdetail.FldTripType, DbType.String);
                parameters.Add("fldTripStartLocationName", tbltripdetail.FldTripStartLocationName, DbType.String);
                parameters.Add("fldTripStartLocationAddress", tbltripdetail.FldTripStartLocationAddress, DbType.String);
                parameters.Add("fldTripDestinationLocationName", tbltripdetail.FldTripDestinationLocationName, DbType.String);
                parameters.Add("fldTripDestinationLocationAddress", tbltripdetail.FldTripDestinationLocationAddress, DbType.String);
                parameters.Add("fldUpdateDate", tbltripdetail.FldUpdateDate, DbType.DateTime);
                parameters.Add("fldUpdateBy", tbltripdetail.FldUpdateBy, DbType.String);

                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public async Task<int> DeleteTripDetail(string planDetailId)
        {
            try
            {
                var query = "DELETE FROM tbltripdetail WHERE fldTripId = @fldTripId";

                var parameters = new DynamicParameters();
                parameters.Add("fldTripId", planDetailId, DbType.String);
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
