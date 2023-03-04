using Dapper;
using JourneySick.Data.Helpers;
using JourneySick.Data.Models.Entities;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace JourneySick.Data.IRepositories.Repositories
{
    public class TripRepository : BaseRepository, ITripRepository
    {
        public TripRepository(IConfiguration configuration) : base(configuration)
        {
        }

        //CREATE
        public async Task<int> CreateTrip(Tbltrip tripEntity)
        {
            try
            {
                var query = "INSERT INTO tbltrip ("
                    + "         fldTripId, "
                    + "         fldTripName, "
                    + "         fldTripBudget, "
                    + "         fldTripDescription, "
                    + "         fldEstimateStartTime, "
                    + "         fldEstimateArrivalTime, "
                    + "         fldTripStatus, "
                    + "         fldTripMember) "
                    + "     VALUES ( "
                    + "         @fldTripId, "
                    + "         @fldTripName, "
                    + "         @fldTripBudget, "
                    + "         @fldTripDescription, "
                    + "         @fldEstimateStartTime, "
                    + "         @fldEstimateArrivalTime, "
                    + "         @fldTripStatus, "
                    + "         @fldTripMember) ";

                var parameters = new DynamicParameters();
                parameters.Add("fldTripId", tripEntity.FldTripId, DbType.String);
                parameters.Add("fldTripName", tripEntity.FldTripName, DbType.String);
                parameters.Add("fldTripBudget", tripEntity.FldTripBudget, DbType.Decimal);
                parameters.Add("fldTripDescription", tripEntity.FldTripDescription, DbType.String);
                parameters.Add("fldEstimateStartTime", tripEntity.FldEstimateStartTime, DbType.DateTime);
                parameters.Add("fldEstimateArrivalTime", tripEntity.FldEstimateArrivalTime, DbType.DateTime);
                parameters.Add("fldTripStatus", tripEntity.FldTripStatus, DbType.String);
                parameters.Add("fldTripMember", tripEntity.FldTripMember, DbType.String);

                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query,parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> DeleteTrip(string tripId)
        {
            try
            {
                var query = "DELETE FROM tbltrip WHERE fldTripId = @fldTripId";

                var parameters = new DynamicParameters();
                parameters.Add("fldTripId", tripId, DbType.String);
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<string> GetLastOneId()
        {
            try
            {
                var query = "SELECT MAX(fldTripId) FROM tbltrip ";
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<string>(query);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<Tbltrip> SelectTrip(string tripId)
        {
            try
            {
                var query = "SELECT * FROM tbltrip WHERE fldTripId = @fldTripId";

                var parameters = new DynamicParameters();
                parameters.Add("fldTripId", tripId, DbType.String);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<Tbltrip>(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> UpdateTrip(Tbltrip tripEntity)
        {
            try
            {
                var query = "UPDATE tbltrip SET"
                    + "         fldTripId = @fldTripId, "
                    + "         fldTripName = @fldTripName, "
                    + "         fldTripBudget = @fldTripBudget, "
                    + "         fldTripDescription = @fldTripDescription, "
                    + "         fldEstimateStartTime = @fldEstimateStartTime, "
                    + "         fldEstimateArrivalTime = @fldEstimateArrivalTime, "
                    + "         fldTripStatus = @fldTripStatus, "
                    + "         fldTripMember = @fldTripMember";

                var parameters = new DynamicParameters();
                parameters.Add("fldTripId", tripEntity.FldTripId, DbType.String);
                parameters.Add("fldTripName", tripEntity.FldTripName, DbType.String);
                parameters.Add("fldTripBudget", tripEntity.FldTripBudget, DbType.Decimal);
                parameters.Add("fldTripDescription", tripEntity.FldTripDescription, DbType.String);
                parameters.Add("fldEstimateStartTime", tripEntity.FldEstimateStartTime, DbType.DateTime);
                parameters.Add("fldEstimateArrivalTime", tripEntity.FldEstimateArrivalTime, DbType.DateTime);
                parameters.Add("fldTripStatus", tripEntity.FldTripStatus, DbType.String);
                parameters.Add("fldTripMember", tripEntity.FldTripMember, DbType.String);

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
