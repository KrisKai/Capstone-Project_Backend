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
                    + "         fldTripStartLocationName, "
                    + "         fldTripStartLocationAddress, "
                    + "         fldTripDestinationLocationName, "
                    + "         fldTripDestinationLocationAddress, "
                    + "         fldCreateDate, "
                    + "         fldCreateBy) "
                    + "     VALUES ( "
                    + "         @fldTripId, "
                    + "         @fldTripStartLocationId, "
                    + "         @fldTripDestinationLocationId, "
                    + "         @fldCreateDate, "
                    + "         @fldCreateBy)";

                var parameters = new DynamicParameters();
                parameters.Add("fldTripId", tbltripdetail.FldTripId, DbType.String);
                parameters.Add("fldTripStartLocationId", tbltripdetail.FldTripStartLocationId, DbType.String);
                parameters.Add("fldTripDestinationLocationId", tbltripdetail.FldTripDestinationLocationId, DbType.String);
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
                    + "         fldUpdateDate = @fldUpdateDate, "
                    + "         fldUpdateBy = @fldUpdateBy"
                    + "     WHERE fldTripId = @fldTripId"; ;

                var parameters = new DynamicParameters();
                parameters.Add("fldTripId", tbltripdetail.FldTripId, DbType.String);
                parameters.Add("fldTripStartLocationId", tbltripdetail.FldTripStartLocationId, DbType.String);
                parameters.Add("fldTripDestinationLocationId", tbltripdetail.FldTripDestinationLocationId, DbType.String);
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
