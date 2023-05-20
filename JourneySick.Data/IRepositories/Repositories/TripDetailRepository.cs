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
                var query = "INSERT INTO tripdetail ("
                    + "         TripId, "
                    + "         TripStartLocationId, "
                    + "         TripDestinationLocationId, "
                    + "         EstimateStartDate, "
                    + "         EstimateStartTime, "
                    + "         EstimateEndDate, "
                    + "         EstimateEndTime, "
                    + "         Distance, "
                    + "         CreateDate, "
                    + "         CreateBy) "
                    + "     VALUES ( "
                    + "         @TripId, "
                    + "         @TripStartLocationId, "
                    + "         @TripDestinationLocationId, "
                    + "         @EstimateStartDate, "
                    + "         @EstimateStartTime, "
                    + "         @EstimateEndDate, "
                    + "         @EstimateEndTime, "
                    + "         @Distance, "
                    + "         @CreateDate, "
                    + "         @CreateBy)";

                var parameters = new DynamicParameters();
                parameters.Add("TripId", tripdetail.TripId, DbType.String);
                parameters.Add("TripStartLocationId", tripdetail.TripStartLocationId, DbType.Int32);
                parameters.Add("EstimateStartDate", tripdetail.EstimateStartDate, DbType.Date);
                parameters.Add("EstimateStartTime", tripdetail.EstimateStartTime, DbType.String);
                parameters.Add("EstimateEndDate", tripdetail.EstimateEndDate, DbType.Date);
                parameters.Add("EstimateEndTime", tripdetail.EstimateEndTime, DbType.Single);
                parameters.Add("Distance", tripdetail.Distance, DbType.Decimal);
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
                var query = "UPDATE tripdetail SET"
                    + "         TripStartLocationId = @TripStartLocationId, "
                    + "         TripDestinationLocationId = @TripDestinationLocationId, "
                    + "         EstimateStartDate = @EstimateStartDate, "
                    + "         EstimateStartTime = @EstimateStartTime, "
                    + "         EstimateEndDate = @EstimateEndDate, "
                    + "         EstimateEndTime = @EstimateEndTime, "
                    + "         Distance = @Distance, "
                    + "         UpdateDate = @UpdateDate, "
                    + "         UpdateBy = @UpdateBy"
                    + "     WHERE TripId = @TripId"; ;

                var parameters = new DynamicParameters();
                parameters.Add("TripId", tripdetail.TripId, DbType.String);
                parameters.Add("TripStartLocationId", tripdetail.TripStartLocationId, DbType.Int32);
                parameters.Add("EstimateStartDate", tripdetail.EstimateStartDate, DbType.Date);
                parameters.Add("EstimateStartTime", tripdetail.EstimateStartTime, DbType.String);
                parameters.Add("EstimateEndDate", tripdetail.EstimateEndDate, DbType.Date);
                parameters.Add("EstimateEndTime", tripdetail.EstimateEndTime, DbType.Single);
                parameters.Add("Distance", tripdetail.Distance, DbType.Decimal);
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
                var query = "DELETE FROM tripdetail WHERE TripId = @TripId";

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
