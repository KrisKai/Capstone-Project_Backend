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
        
        public async Task<int> CreateTripDetail(Tbltripdetail tbltripdetail)
        {
            try
            {
                var query = "INSERT INTO tbltripdetail ("
                    + "         fldTripId, "
                    + "         fldTripStartLocationId, "
                    + "         fldTripDestinationLocationId, "
                    + "         fldEstimateStartDate, "
                    + "         fldEstimateStartTime, "
                    + "         fldEstimateEndDate, "
                    + "         fldEstimateEndTime, "
                    + "         fldDistance, "
                    + "         fldCreateDate, "
                    + "         fldCreateBy) "
                    + "     VALUES ( "
                    + "         @fldTripId, "
                    + "         @fldTripStartLocationId, "
                    + "         @fldTripDestinationLocationId, "
                    + "         @fldEstimateStartDate, "
                    + "         @fldEstimateStartTime, "
                    + "         @fldEstimateEndDate, "
                    + "         @fldEstimateEndTime, "
                    + "         @fldDistance, "
                    + "         @fldCreateDate, "
                    + "         @fldCreateBy)";

                var parameters = new DynamicParameters();
                parameters.Add("fldTripId", tbltripdetail.FldTripId, DbType.String);
                parameters.Add("fldTripStartLocationId", tbltripdetail.FldTripStartLocationId, DbType.Int32);
                parameters.Add("fldEstimateStartDate", tbltripdetail.FldEstimateStartDate, DbType.Date);
                parameters.Add("fldEstimateStartTime", tbltripdetail.FldEstimateStartTime, DbType.String);
                parameters.Add("fldEstimateEndDate", tbltripdetail.FldEstimateEndDate, DbType.Date);
                parameters.Add("fldEstimateEndTime", tbltripdetail.FldEstimateEndTime, DbType.Single);
                parameters.Add("fldDistance", tbltripdetail.FldDistance, DbType.Decimal);
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
                    + "         fldTripStartLocationId = @fldTripStartLocationId, "
                    + "         fldTripDestinationLocationId = @fldTripDestinationLocationId, "
                    + "         fldEstimateStartDate = @fldEstimateStartDate, "
                    + "         fldEstimateStartTime = @fldEstimateStartTime, "
                    + "         fldEstimateEndDate = @fldEstimateEndDate, "
                    + "         fldEstimateEndTime = @fldEstimateEndTime, "
                    + "         fldDistance = @fldDistance, "
                    + "         fldUpdateDate = @fldUpdateDate, "
                    + "         fldUpdateBy = @fldUpdateBy"
                    + "     WHERE fldTripId = @fldTripId"; ;

                var parameters = new DynamicParameters();
                parameters.Add("fldTripId", tbltripdetail.FldTripId, DbType.String);
                parameters.Add("fldTripStartLocationId", tbltripdetail.FldTripStartLocationId, DbType.Int32);
                parameters.Add("fldEstimateStartDate", tbltripdetail.FldEstimateStartDate, DbType.Date);
                parameters.Add("fldEstimateStartTime", tbltripdetail.FldEstimateStartTime, DbType.String);
                parameters.Add("fldEstimateEndDate", tbltripdetail.FldEstimateEndDate, DbType.Date);
                parameters.Add("fldEstimateEndTime", tbltripdetail.FldEstimateEndTime, DbType.Single);
                parameters.Add("fldDistance", tbltripdetail.FldDistance, DbType.Decimal);
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
