using Dapper;
using JourneySick.Data.Helpers;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;
using JourneySick.Data.Models.Enums;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;

namespace JourneySick.Data.IRepositories.Repositories
{
    public class FeedbackRepository : BaseRepository, IFeedbackRepository
    {
        public FeedbackRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<Models.Entities.VO.FeedbackVO>> GetAllFeedbacksWithPaging(int pageIndex, int pageSize, string? tripId)
        {
            try
            {
                int firstIndex = pageIndex * pageSize;
                int lastIndex = (pageIndex + 1) * pageSize;
                tripId ??= "";
                var query = "SELECT * FROM Feedback a INNER JOIN User b ON a.UserId = b.UserId INNER JOIN User_Detail c ON a.UserId = c.UserId INNER JOIN Trip d ON a.TripId = d.TripId  WHERE a.TripId LIKE CONCAT('%', @tripId, '%') LIMIT @firstIndex, @lastIndex";
                
                var parameters = new DynamicParameters();
                parameters.Add("firstIndex", firstIndex, DbType.Int16);
                parameters.Add("lastIndex", lastIndex, DbType.Int16);
                parameters.Add("tripId", tripId, DbType.String);

                using var connection = CreateConnection();
                return (await connection.QueryAsync<Models.Entities.VO.FeedbackVO>(query, parameters)).ToList();
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
                var query = "SELECT COUNT(*) FROM Feedback WHERE TripId LIKE CONCAT('%', @tripId, '%')";
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
                var query = "SELECT * FROM Feedback WHERE FeedbackId = @FeedbackId";

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
        public async Task<int> CreateFeedback(Feedback feedbackEntity)
        {
            try
            {
                var query = "INSERT INTO Feedback ("
                    + "         TripId, "
                    + "         UserId, "
                    + "         Feedback, "
                    + "         Rate, "
                    + "         Like, "
                    + "         Dislike, "
                    + "         LocationName, "
                    + "         CreateDate, "
                    + "         CreateBy) "
                    + "     VALUES ( "
                    + "         @TripId, "
                    + "         @UserId, "
                    + "         @Feedback, "
                    + "         @Rate, "
                    + "         @Like, "
                    + "         @Dislike, "
                    + "         @LocationName, "
                    + "         @CreateDate, "
                    + "         @CreateBy)";

                var parameters = new DynamicParameters();
                parameters.Add("TripId", feedbackEntity.TripId, DbType.String);
                parameters.Add("UserId", feedbackEntity.UserId, DbType.String);
                parameters.Add("Feedback", feedbackEntity.FeedbackDescription, DbType.String);
                parameters.Add("Rate", feedbackEntity.Rate, DbType.Double);
                parameters.Add("Like", feedbackEntity.Like, DbType.Int32);
                parameters.Add("Dislike", feedbackEntity.Dislike, DbType.Int32);
                parameters.Add("LocationName", feedbackEntity.LocationName, DbType.String);
                parameters.Add("CreateDate", feedbackEntity.CreateDate, DbType.DateTime);
                parameters.Add("CreateBy", feedbackEntity.CreateBy, DbType.String);

                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
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
                var query = "UPDATE Feedback ("
                    + "         Feedback = @Feedback, "
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
                var query = "DELETE FROM Feedback WHERE FeedbackId = @FeedbackId";

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

        public async Task<List<Models.Entities.VO.FeedbackVO>> GetTopFeedback()
        {
            try
            {
                var query = "SELECT Username, Like, Dislike, LocationName, Rate, Feedback FROM Feedback a INNER JOIN user b ON a.UserId = b.UserId INNER JOIN userdetail c ON a.UserId = c.UserId INNER JOIN trip d ON a.TripId = d.TripId ORDER BY Like LIMIT 10";

                using var connection = CreateConnection();
                return (await connection.QueryAsync<Models.Entities.VO.FeedbackVO>(query)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> IncreaseLike(Feedback feedbackDTO, string status)
        {
            try
            {
                var query = "";
                var parameters = new DynamicParameters();
                if (status.Equals("L"))
                {
                    query = "UPDATE Feedback ("
                    + "         Like = @Like, "
                    + "      WHERE FeedbackId = @FeedbackId";
                    parameters.Add("Like", feedbackDTO.Like, DbType.Int32);
                }
                else if(status.Equals("D"))
                {
                    query = "UPDATE Feedback ("
                    + "         Dislike = @Dislike, "
                    + "      WHERE FeedbackId = @FeedbackId";
                    parameters.Add("Dislike", feedbackDTO.Dislike, DbType.Int32);
                }
                parameters.Add("FeedbackId", feedbackDTO.FeedbackId, DbType.Int32);

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
