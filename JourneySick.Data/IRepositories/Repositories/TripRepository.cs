﻿using Dapper;
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

        public async Task<List<Tbltrip>> GetAllTripsWithPaging(int pageIndex, int pageSize, String? tripName)
        {
            try
            {
                int firstIndex = (pageIndex) * pageSize;
                int lastIndex = (pageIndex + 1) * pageSize;
                var parameters = new DynamicParameters();
                parameters.Add("firstIndex", firstIndex, DbType.Int16);
                parameters.Add("lastIndex", lastIndex, DbType.Int16);
                tripName ??= "";
                parameters.Add("tripName", tripName, DbType.String);

                var query = "SELECT * FROM tbltrip WHERE fldTripName LIKE CONCAT('%', @tripName, '%')  LIMIT @firstIndex, @lastIndex";

                using var connection = CreateConnection();
                return (await connection.QueryAsync<Tbltrip>(query, parameters)).ToList();
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
                var query = "SELECT COALESCE(MAX(fldTripId), 0) FROM tbltrip ";
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<string>(query);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<Tbltrip> GetTripById(string tripId)
        {
            try
            {
                var query = "SELECT * FROM tbltrip WHERE fldTripId = @tripId";

                var parameters = new DynamicParameters();
                parameters.Add("tripId", tripId, DbType.String);

                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<Tbltrip>(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
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
                return await connection.ExecuteAsync(query, parameters);
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

        public async Task<int> CountAllTrips()
        {
            try
            {
                var query = "SELECT COUNT(*) FROM tbltrip";
                using var connection = CreateConnection();
                return ((int)(long)connection.ExecuteScalar(query));

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}
