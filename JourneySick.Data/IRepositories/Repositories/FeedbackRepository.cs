using Dapper;
using JourneySick.Business.Models.DTOs;
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

        public async Task<List<Tblfeedback>> GetAllFeedbacksWithPaging(int pageIndex, int pageSize, string? tripId)
        {
            try
            {
                int firstIndex = pageIndex * pageSize;
                int lastIndex = (pageIndex + 1) * pageSize;
                tripId ??= "";
                var query = "SELECT * FROM tblfeedback WHERE fldTripId LIKE CONCAT('%', @tripId, '%') LIMIT @firstIndex, @lastIndex";
                
                var parameters = new DynamicParameters();
                parameters.Add("firstIndex", firstIndex, DbType.Int16);
                parameters.Add("lastIndex", lastIndex, DbType.Int16);
                parameters.Add("tripId", tripId, DbType.String);

                using var connection = CreateConnection();
                return (await connection.QueryAsync<Tblfeedback>(query, parameters)).ToList();
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
                var query = "SELECT COUNT(*) FROM tblfeedback WHERE fldTripId LIKE CONCAT('%', @tripId, '%')";
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
        public async Task<Tblfeedback> GetFeedbackById(int tripId)
        {
            try
            {
                var query = "SELECT * FROM tblfeedback WHERE fldFeedbackId = @fldFeedbackId";

                var parameters = new DynamicParameters();
                parameters.Add("fldFeedbackId", tripId, DbType.String);

                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<Tblfeedback>(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        //CREATE
        public async Task<int> CreateFeedback(Tblfeedback feedbackEntity)
        {
            try
            {
                var query = "INSERT INTO tblfeedback ("
                    + "         fldTripId, "
                    + "         fldUserId, "
                    + "         fldFeedback, "
                    + "         fldRate, "
                    + "         fldLike, "
                    + "         fldDislike, "
                    + "         fldLocationName, "
                    + "         fldCreateDate, "
                    + "         fldCreateBy) "
                    + "     VALUES ( "
                    + "         @fldTripId, "
                    + "         @fldUserId, "
                    + "         @fldFeedback, "
                    + "         @fldRate, "
                    + "         @fldLike, "
                    + "         @fldDislike, "
                    + "         @fldLocationName, "
                    + "         @fldCreateDate, "
                    + "         @fldCreateBy)";

                var parameters = new DynamicParameters();
                parameters.Add("fldTripId", feedbackEntity.FldTripId, DbType.String);
                parameters.Add("fldUserId", feedbackEntity.FldUserId, DbType.String);
                parameters.Add("fldFeedback", feedbackEntity.FldFeedback, DbType.String);
                parameters.Add("fldRate", feedbackEntity.FldRate, DbType.Double);
                parameters.Add("fldLike", feedbackEntity.FldLike, DbType.Int32);
                parameters.Add("fldDislike", feedbackEntity.FldDislike, DbType.Int32);
                parameters.Add("fldLocationName", feedbackEntity.FldLocationName, DbType.String);
                parameters.Add("fldCreateDate", feedbackEntity.FldCreateDate, DbType.DateTime);
                parameters.Add("fldCreateBy", feedbackEntity.FldCreateBy, DbType.String);

                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> UpdateFeedback(Tblfeedback feedbackEntity)
        {
            try
            {
                var query = "UPDATE tblfeedback ("
                    + "         fldFeedback = @fldFeedback, "
                    + "         fldRate = @fldRate, "
                    + "         fldUpdateDate = @fldUpdateDate, "
                    + "         fldUpdateBy = @fldUpdateBy "
                    + "      WHERE fldFeedbackId = @fldFeedbackId";

                var parameters = new DynamicParameters();
                parameters.Add("fldFeedbackId", feedbackEntity.FldFeedbackId, DbType.String);
                parameters.Add("fldFeedback", feedbackEntity.FldFeedback, DbType.String);
                parameters.Add("fldRate", feedbackEntity.FldRate, DbType.Double);
                parameters.Add("fldUpdateDate", feedbackEntity.FldUpdateDate, DbType.DateTime);
                parameters.Add("fldUpdateBy", feedbackEntity.FldUpdateBy, DbType.String);

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
                var query = "DELETE FROM tblfeedback WHERE fldFeedbackId = @fldFeedbackId";

                var parameters = new DynamicParameters();
                parameters.Add("fldFeedbackId", tripId, DbType.String);
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
