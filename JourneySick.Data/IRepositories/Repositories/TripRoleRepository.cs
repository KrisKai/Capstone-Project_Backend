using Dapper;
using JourneySick.Data.Helpers;
using JourneySick.Data.Models.Entities;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace JourneySick.Data.IRepositories.Repositories
{
    public class TripRoleRepository : BaseRepository, ITripRoleRepository
    {
        public TripRoleRepository(IConfiguration configuration) : base(configuration)
        {
        }

        //CREATE
        public async Task<int> CreateTripRole(Tbltriprole tbltriprole)
        {
            try
            {
                var query = "INSERT INTO tbltriprole ("
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
                /*parameters.Add("fldTripId", tbltriprole.FldTripId, DbType.String);
                parameters.Add("fldTripName", tbltriprole.FldTripName, DbType.String);
                parameters.Add("fldTripBudget", tbltriprole.FldTripBudget, DbType.Decimal);
                parameters.Add("fldTripDescription", tbltriprole.FldTripDescription, DbType.String);
                parameters.Add("fldEstimateStartTime", tbltriprole.FldEstimateStartTime, DbType.DateTime);
                parameters.Add("fldEstimateArrivalTime", tbltriprole.FldEstimateArrivalTime, DbType.DateTime);
                parameters.Add("fldTripStatus", tbltriprole.FldTripStatus, DbType.String);
                parameters.Add("fldTripMember", tbltriprole.FldTripMember, DbType.String);*/

                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query,parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> DeleteTripRole(int roleId)
        {
            try
            {
                var query = "DELETE FROM tbltriprole WHERE fldRoleId = @fldRoleId";

                var parameters = new DynamicParameters();
                parameters.Add("fldRoleId", roleId, DbType.Int16);
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> GetLastOneId()
        {
            try
            {
                var query = "SELECT MAX(fldRoleId) FROM tbltriprole ";
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<int>(query);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<Tbltriprole> SelectTripRole(int roleId)
        {
            try
            {
                var query = "SELECT * FROM tbltriprole WHERE fldRoleId = @fldRoleId";

                var parameters = new DynamicParameters();
                parameters.Add("fldRoleId", roleId, DbType.Int16);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<Tbltriprole>(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> UpdateTripRole(Tbltriprole tbltriprole)
        {
            try
            {
                var query = "UPDATE tbltriprole SET"
                    + "         fldTripId = @fldTripId, "
                    + "         fldTripName = @fldTripName, "
                    + "         fldTripBudget = @fldTripBudget, "
                    + "         fldTripDescription = @fldTripDescription, "
                    + "         fldEstimateStartTime = @fldEstimateStartTime, "
                    + "         fldEstimateArrivalTime = @fldEstimateArrivalTime, "
                    + "         fldTripStatus = @fldTripStatus, "
                    + "         fldTripMember = @fldTripMember";

                var parameters = new DynamicParameters();
                /*parameters.Add("fldTripId", tripEntity.FldTripId, DbType.String);
                parameters.Add("fldTripName", tripEntity.FldTripName, DbType.String);
                parameters.Add("fldTripBudget", tripEntity.FldTripBudget, DbType.Decimal);
                parameters.Add("fldTripDescription", tripEntity.FldTripDescription, DbType.String);
                parameters.Add("fldEstimateStartTime", tripEntity.FldEstimateStartTime, DbType.DateTime);
                parameters.Add("fldEstimateArrivalTime", tripEntity.FldEstimateArrivalTime, DbType.DateTime);
                parameters.Add("fldTripStatus", tripEntity.FldTripStatus, DbType.String);
                parameters.Add("fldTripMember", tripEntity.FldTripMember, DbType.String);*/

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
