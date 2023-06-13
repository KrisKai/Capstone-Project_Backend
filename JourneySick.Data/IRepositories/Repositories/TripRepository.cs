using Dapper;
using Dapper.Transaction;
using JourneySick.Data.Helpers;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace JourneySick.Data.IRepositories.Repositories
{
    public class TripRepository : BaseRepository, ITripRepository
    {
        public TripRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<TripVO>> GetAllTripsWithPaging(int pageIndex, int pageSize, String? tripName)
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

                var query = "SELECT * " +
                    "FROM trip a INNER JOIN trip_detail b ON a.TripId = b.TripId " +
                    "WHERE a.TripName " +
                    "LIKE CONCAT('%', @tripName, '%') " +
                    "LIMIT @firstIndex, @lastIndex";

                using var connection = CreateConnection();
                return (await connection.QueryAsync<TripVO>(query, parameters)).ToList();
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
                var query = "SELECT COALESCE(MAX(TripId), 0) FROM trip ";
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<string>(query);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<TripVO> GetTripById(string tripId)
        {
            try
            {
                var query = "SELECT * FROM trip a INNER JOIN trip_detail b ON a.TripId = b.TripId WHERE a.TripId = @tripId";

                var parameters = new DynamicParameters();
                parameters.Add("tripId", tripId, DbType.String);

                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<TripVO>(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }


        //CREATE
        public async Task<int> CreateTrip(TripVO tripEntity)
        {
            try
            {
                var query = "INSERT INTO trip ("
                    + "         TripId, "
                    + "         TripThumbnail, "
                    + "         TripName, "
                    + "         TripBudget, "
                    + "         TripDescription, "
                    + "         TripStatus, "
                    + "         TripPresenter, "
                    + "         TripMember) "
                    + "     VALUES ( "
                    + "         @TripId, "
                    + "         @TripThumbnail,"
                    + "         @TripName, "
                    + "         @TripBudget, "
                    + "         @TripDescription, "
                    + "         @TripStatus, "
                    + "         @TripPresenter, "
                    + "         @TripMember) ";

                var parameters = new DynamicParameters();
                parameters.Add("TripId", tripEntity.TripId, DbType.String);
                parameters.Add("TripThumbnail", tripEntity.TripThumbnail, DbType.String);
                parameters.Add("TripName", tripEntity.TripName, DbType.String);
                parameters.Add("TripBudget", tripEntity.TripBudget, DbType.Decimal);
                parameters.Add("TripDescription", tripEntity.TripDescription, DbType.String);
                parameters.Add("TripStatus", tripEntity.TripStatus, DbType.String);
                parameters.Add("TripMember", tripEntity.TripMember, DbType.String);
                parameters.Add("TripPresenter", tripEntity.TripPresenter, DbType.String);

                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> UpdateTrip(TripVO tripEntity)
        {
            try
            {
                var query = "UPDATE trip SET"
                    + "         TripName = @TripName, "
                    + "         TripDescription = @TripDescription, "
                    + "         TripStatus = @TripStatus, "
                    + "         TripMember = @TripMember,"
                    + "         TripPresenter = @TripPresenter"
                    + "      WHERE TripId = @TripId";

                var parameters = new DynamicParameters();
                parameters.Add("TripId", tripEntity.TripId, DbType.String);
                parameters.Add("TripName", tripEntity.TripName, DbType.String);
                parameters.Add("TripDescription", tripEntity.TripDescription, DbType.String);
                parameters.Add("TripStatus", tripEntity.TripStatus, DbType.String);
                parameters.Add("TripMember", tripEntity.TripMember, DbType.String);
                parameters.Add("TripPresenter", tripEntity.TripPresenter, DbType.String);

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
                var query = "DELETE FROM trip WHERE TripId = @TripId";

                var parameters = new DynamicParameters();
                parameters.Add("TripId", tripId, DbType.String);
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> CountAllTrips(string? tripName)
        {
            try
            {
                var query = "SELECT COUNT(*) FROM trip WHERE TripName LIKE CONCAT('%', @tripName, '%')";

                tripName ??= "";
                var parameters = new DynamicParameters();
                parameters.Add("tripName", tripName, DbType.String);
                using var connection = CreateConnection();
                return ((int)(long)connection.ExecuteScalar(query, parameters));

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> UpdateTripBudget(TripVO trip)
        {
            try
            {
                var query = "UPDATE trip SET"
                    + "         TripBudget = @TripBudget"
                    + "      WHERE TripId = @TripId";

                var parameters = new DynamicParameters();
                parameters.Add("TripId", trip.TripId, DbType.String);
                parameters.Add("TripBudget", trip.TripBudget, DbType.Decimal);

                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> CountTripCreatedThisMonth()
        {
            try
            {
                var query = "SELECT COUNT(*) FROM trip_detail WHERE MONTH(CreateDate) = MONTH(now()) and YEAR(CreateDate) = YEAR(now())";
                using var connection = CreateConnection();
                return ((int)(long)connection.ExecuteScalar(query));

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> CountTripCreatedPreviousMonth()
        {
            try
            {
                var query = "SELECT COUNT(*) FROM trip_detail WHERE MONTH(CreateDate) = MONTH(CURRENT_DATE - INTERVAL 1 MONTH) and YEAR(CreateDate) = YEAR(now())";
                using var connection = CreateConnection();
                return ((int)(long)connection.ExecuteScalar(query));

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> CountTripCreatedThisYear()
        {
            try
            {
                var query = "SELECT COUNT(*) FROM trip_detail WHERE YEAR(CreateDate) = YEAR(now())";
                using var connection = CreateConnection();
                return ((int)(long)connection.ExecuteScalar(query));

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<List<TripVO>> GetTripHistoryByUserId(string userId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("userId", userId, DbType.String);

                var query = "SELECT a.*, b.*, TripStatus, FeedbackDescription, `Rate`, FeedbackId " +
                    "FROM trip a INNER JOIN trip_detail b ON a.TripId = b.TripId " +
                    "INNER JOIN trip_member c ON a.TripId = c.TripId " +
                    "LEFT JOIN feedback d ON (a.TripId = d.TripId AND c.UserId = d.UserId)" +
                    "WHERE c.UserId = @userId";

                using var connection = CreateConnection();
                return (await connection.QueryAsync<TripVO>(query, parameters)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}
