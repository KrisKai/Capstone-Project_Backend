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
        
        public async Task<int> CreateTripDetail(TripDetail tripdetail)
        {
            try
            {
                var query = "INSERT INTO trip_detail ("
                    + "         TripId, "
                    + "         TripDestinationLocationId, "
                    + "         EstimateStartDate, "
                    + "         EstimateEndDate, "
                    + "         CreateDate, "
                    + "         CreateBy) "
                    + "     VALUES ( "
                    + "         @TripId, "
                    + "         @TripDestinationLocationId, "
                    + "         @EstimateStartDate, "
                    + "         @EstimateEndDate, "
                    + "         @CreateDate, "
                    + "         @CreateBy)";

                var parameters = new DynamicParameters();
                parameters.Add("TripId", tripdetail.TripId, DbType.String);
                parameters.Add("TripDestinationLocationId", tripdetail.TripDestinationLocationId, DbType.Int32);
                parameters.Add("EstimateStartDate", tripdetail.EstimateStartDate, DbType.DateTime);
                parameters.Add("EstimateEndDate", tripdetail.EstimateEndDate, DbType.DateTime);
                parameters.Add("CreateDate", tripdetail.CreateDate, DbType.DateTime);
                parameters.Add("CreateBy", tripdetail.CreateBy, DbType.String);

                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> UpdateTripDetail(TripDetail tripdetail)
        {
            try
            {
                var query = "UPDATE trip_detail SET"
                    + "         TripDestinationLocationId = @TripDestinationLocationId, "
                    + "         EstimateStartDate = @EstimateStartDate, "
                    + "         EstimateEndDate = @EstimateEndDate, "
                    + "         UpdateDate = @UpdateDate, "
                    + "         UpdateBy = @UpdateBy"
                    + "     WHERE TripId = @TripId"; ;

                var parameters = new DynamicParameters();
                parameters.Add("TripId", tripdetail.TripId, DbType.String);
                parameters.Add("TripDestinationLocationId", tripdetail.TripDestinationLocationId, DbType.Int32);
                parameters.Add("EstimateStartDate", tripdetail.EstimateStartDate, DbType.DateTime);
                parameters.Add("EstimateEndDate", tripdetail.EstimateEndDate, DbType.DateTime);
                parameters.Add("UpdateDate", tripdetail.UpdateDate, DbType.DateTime);
                parameters.Add("UpdateBy", tripdetail.UpdateBy, DbType.String);

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
                var query = "DELETE FROM trip_detail WHERE TripId = @TripId";

                var parameters = new DynamicParameters();
                parameters.Add("TripId", planDetailId, DbType.String);
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
