using Dapper;
using Dapper.Transaction;
using JourneySick.Data.Helpers;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace JourneySick.Data.IRepositories.Repositories
{
    public class FeedbackRepository : BaseRepository, IFeedbackRepository
    {
        public FeedbackRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<FeedbackVO>> GetAllFeedbacksWithPaging(int pageIndex, int pageSize, string? tripId)
        {
            try
            {
                int firstIndex = pageIndex * pageSize;
                int lastIndex = (pageIndex + 1) * pageSize;
                tripId ??= "";
                var query = "";
                if (query.Equals(""))
                {
                    query = "SELECT * " +
                    "FROM feedback a INNER JOIN user b ON a.UserId = b.UserId " +
                    "INNER JOIN user_detail c ON a.UserId = c.UserId " +
                    "LIMIT @firstIndex, @lastIndex";
                } else
                {
                    query = "SELECT * " +
                    "FROM feedback a INNER JOIN user b ON a.UserId = b.UserId " +
                    "INNER JOIN user_detail c ON a.UserId = c.UserId " +
                    "INNER JOIN Trip d ON a.TripId = d.TripId " +
                    "WHERE a.TripId LIKE CONCAT('%', @tripId, '%') " +
                    "LIMIT @firstIndex, @lastIndex";
                }
                
                var parameters = new DynamicParameters();
                parameters.Add("firstIndex", firstIndex, DbType.Int16);
                parameters.Add("lastIndex", lastIndex, DbType.Int16);
                parameters.Add("tripId", tripId, DbType.String);

                using var connection = CreateConnection();
                return (await connection.QueryAsync<FeedbackVO>(query, parameters)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> CountAllFeedbacks(string? tripId)
        {
            try
            {
                var query = "SELECT COUNT(*) FROM feedback WHERE TripId LIKE CONCAT('%', @tripId, '%')";
                tripId ??= "";
                var parameters = new DynamicParameters();
                parameters.Add("tripId", tripId, DbType.String);
                using var connection = CreateConnection();
                return ((int)(long)connection.ExecuteScalar(query, parameters));

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        //SELECT
        public async Task<Feedback> GetFeedbackById(int tripId)
        {
            try
            {
                var query = "SELECT * FROM feedback WHERE FeedbackId = @FeedbackId";

                var parameters = new DynamicParameters();
                parameters.Add("FeedbackId", tripId, DbType.String);

                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<Feedback>(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        //CREATE
        public async Task<long> CreateFeedback(Feedback feedbackEntity)
        {
            try
            {
                long lastId;
                var query = "INSERT INTO feedback ("
                    + "         TripId, "
                    + "         UserId, "
                    + "         FeedbackDescription, "
                    + "         Rate, "
                    + "         LocationName, "
                    + "         CreateDate, "
                    + "         CreateBy) "
                    + "     VALUES ( "
                    + "         @TripId, "
                    + "         @UserId, "
                    + "         @FeedbackDescription, "
                    + "         @Rate, "
                    + "         @LocationName, "
                    + "         @CreateDate, "
                    + "         @CreateBy)";
                var getLastId = "SELECT LAST_INSERT_ID()";

                var parameters = new DynamicParameters();
                parameters.Add("TripId", feedbackEntity.TripId, DbType.String);
                parameters.Add("UserId", feedbackEntity.UserId, DbType.String);
                parameters.Add("FeedbackDescription", feedbackEntity.FeedbackDescription, DbType.String);
                parameters.Add("Rate", feedbackEntity.Rate, DbType.Double);
                parameters.Add("LocationName", feedbackEntity.LocationName, DbType.String);
                parameters.Add("CreateDate", feedbackEntity.CreateDate, DbType.DateTime);
                parameters.Add("CreateBy", feedbackEntity.CreateBy, DbType.String);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using var transaction = connection.BeginTransaction();
                    transaction.Execute(query, parameters);
                    lastId = transaction.ExecuteScalar<long>(getLastId);
                    transaction.Commit();
                }
                return lastId;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> UpdateFeedback(Feedback feedbackEntity)
        {
            try
            {
                var query = "UPDATE feedback SET"
                    + "         FeedbackDescription = @Feedback, "
                    + "         Rate = @Rate, "
                    + "         UpdateDate = @UpdateDate, "
                    + "         UpdateBy = @UpdateBy "
                    + "      WHERE FeedbackId = @FeedbackId";

                var parameters = new DynamicParameters();
                parameters.Add("FeedbackId", feedbackEntity.FeedbackId, DbType.Int32);
                parameters.Add("Feedback", feedbackEntity.FeedbackDescription, DbType.String);
                parameters.Add("Rate", feedbackEntity.Rate, DbType.Double);
                parameters.Add("UpdateDate", feedbackEntity.UpdateDate, DbType.DateTime);
                parameters.Add("UpdateBy", feedbackEntity.UpdateBy, DbType.String);

                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }


        public async Task<int> DeleteFeedback(int tripId)
        {
            try
            {
                var query = "DELETE FROM feedback WHERE FeedbackId = @FeedbackId";

                var parameters = new DynamicParameters();
                parameters.Add("FeedbackId", tripId, DbType.Int32);
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<List<FeedbackVO>> GetTopFeedback()
        {
            try
            {
                var query = "SELECT Fullname, `Like`, Dislike, LocationName, Rate, FeedbackDescription " +
                    "FROM feedback a INNER JOIN user b ON a.UserId = b.UserId " +
                    "INNER JOIN user_detail c ON a.UserId = c.UserId " +
                    "ORDER BY `Like` LIMIT 20";

                using var connection = CreateConnection();
                return (await connection.QueryAsync<FeedbackVO>(query)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> IncreaseLike(Feedback feedbackEntity, string status)
        {
            try
            {
                var query = "";
                var parameters = new DynamicParameters();
                if (status.Equals("L"))
                {
                    query = "UPDATE feedback ("
                    + "         Like = @Like, "
                    + "      WHERE FeedbackId = @FeedbackId";
                    parameters.Add("Like", feedbackEntity.Like, DbType.Int32);
                }
                else if(status.Equals("D"))
                {
                    query = "UPDATE feedback ("
                    + "         Dislike = @Dislike, "
                    + "      WHERE FeedbackId = @FeedbackId";
                    parameters.Add("Dislike", feedbackEntity.Dislike, DbType.Int32);
                }
                parameters.Add("FeedbackId", feedbackEntity.FeedbackId, DbType.Int32);

                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> CountFeedbackByCreatorId(string userId, string tripId)
        {
            try
            {
                var query = "SELECT COUNT(*) FROM feedback WHERE CreateBy LIKE CONCAT('%', @userId, '%') AND TripId = @tripId";
                var parameters = new DynamicParameters();
                parameters.Add("userId", userId, DbType.String);
                parameters.Add("tripId", tripId, DbType.String);
                using var connection = CreateConnection();
                return ((int)(long)connection.ExecuteScalar(query, parameters));

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}
