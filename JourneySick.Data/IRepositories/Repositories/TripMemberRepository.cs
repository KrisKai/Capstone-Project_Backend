﻿using Dapper;
using Dapper.Transaction;
using JourneySick.Data.Helpers;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Numerics;

namespace JourneySick.Data.IRepositories.Repositories
{
    public class TripMemberRepository : BaseRepository, ITripMemberRepository
    {
        public TripMemberRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<TripmemberVO> GetTripMemberById(int memberId)
        {
            try
            {
                var query = "SELECT * FROM trip_member a LEFT JOIN user_detail b ON a.UserId = b.UserId WHERE MemberId = @MemberId";

                var parameters = new DynamicParameters();
                parameters.Add("MemberId", memberId, DbType.Int32);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<TripmemberVO>(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> CountTripMemberByUserIdAndTripId(string userId, string tripId)
        {
            try
            {
                var query = "SELECT COUNT(*) FROM trip_member a LEFT JOIN user_detail b ON a.UserId = b.UserId WHERE a.UserId = @userId AND TripId = @tripId";

                var parameters = new DynamicParameters();
                parameters.Add("userId", userId, DbType.String);
                parameters.Add("tripId", tripId, DbType.String);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<int>(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<List<TripmemberVO>> GetAllTripMembersWithPaging(int pageIndex, int pageSize, string tripId, string? memberName)
        {
            try
            {
                int firstIndex = (pageIndex) * pageSize;
                int lastIndex = (pageIndex + 1) * pageSize;
                var parameters = new DynamicParameters();
                parameters.Add("firstIndex", firstIndex, DbType.Int16);
                parameters.Add("lastIndex", lastIndex, DbType.Int16);

                parameters.Add("tripId", tripId, DbType.String);
                memberName ??= "";
                parameters.Add("NickName", memberName, DbType.String);

                var query = "SELECT * FROM trip_member a LEFT JOIN user_detail b ON a.UserId = b.UserId WHERE TripId = @tripId AND NickName LIKE CONCAT('%', @NickName, '%')  LIMIT @firstIndex, @lastIndex";

                using var connection = CreateConnection();
                return (await connection.QueryAsync<TripmemberVO>(query, parameters)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> CountAllTripMembers(string tripId, string? memberName)
        {
            try
            {
                var query = "SELECT COUNT(*) FROM trip_member WHERE TripId = @tripId AND NickName LIKE CONCAT('%', @NickName, '%')";

                memberName ??= "";
                var parameters = new DynamicParameters();
                parameters.Add("NickName", memberName, DbType.String);
                parameters.Add("tripId", tripId, DbType.String);
                using var connection = CreateConnection();
                return ((int)(long)connection.ExecuteScalar(query, parameters));

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<long> CreateTripMember(TripMember tripmember)
        {
            try
            {
                long lastId;
                var query = "INSERT INTO trip_member ("
                    + "         UserId, "
                    + "         TripId, "
                    + "         MemberRole, "
                    + "         NickName, "
                    + "         Status, "
                    + "         Confirmation, "
                    + "         CreateDate, "
                    + "         CreateBy) "
                    + "     VALUES ( "
                    + "         @UserId, "
                    + "         @TripId, "
                    + "         @MemberRole, "
                    + "         @NickName, "
                    + "         @Status, "
                    + "         @Confirmation, "
                    + "         @CreateDate, "
                    + "         @CreateBy)";
                var getLastId = "SELECT LAST_INSERT_ID()";

                var parameters = new DynamicParameters();
                parameters.Add("UserId", tripmember.UserId, DbType.String);
                parameters.Add("TripId", tripmember.TripId, DbType.String);
                parameters.Add("MemberRole", tripmember.MemberRole, DbType.String);
                parameters.Add("NickName", tripmember.NickName, DbType.String);
                parameters.Add("Status", tripmember.Status, DbType.String);
                parameters.Add("Confirmation", tripmember.Confirmation, DbType.String);
                parameters.Add("CreateDate", tripmember.CreateDate, DbType.DateTime);
                parameters.Add("CreateBy", tripmember.CreateBy, DbType.String);

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

        public async Task<int> UpdateTripMember(TripMember tripmember)
        {
            try
            {
                var query = "UPDATE trip_member SET " +
                    "UserId = @UserId, " +
                    "TripId = @TripId, " +
                    "MemberRole = @MemberRole, " +
                    "NickName = @NickName, " +
                    "Status = @Status, " +
                    "UpdateDate = @UpdateDate, " +
                    "UpdateBy = @UpdateBy " +
                    "WHERE MemberId = @MemberId";

                var parameters = new DynamicParameters();
                parameters.Add("MemberId", tripmember.MemberId, DbType.Int32);
                parameters.Add("UserId", tripmember.UserId, DbType.String);
                parameters.Add("TripId", tripmember.TripId, DbType.String);
                parameters.Add("MemberRole", tripmember.MemberRole, DbType.String);
                parameters.Add("NickName", tripmember.NickName, DbType.String);
                parameters.Add("Status", tripmember.Status, DbType.String);
                parameters.Add("UpdateDate", tripmember.UpdateDate, DbType.DateTime);
                parameters.Add("UpdateBy", tripmember.UpdateBy, DbType.String);
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> DeleteTripMember(int memberId)
        {
            try
            {
                var query = "DELETE FROM trip_member WHERE MemberId = @MemberId";

                var parameters = new DynamicParameters();
                parameters.Add("MemberId", memberId, DbType.Int32);
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> UpdateMemberStatus(TripMember tripmember)
        {
            try
            {
                var query = "UPDATE trip_member SET " +
                    "Status = @Status " +
                    "WHERE UserId = @UserId";

                var parameters = new DynamicParameters();
                parameters.Add("UserId", tripmember.UserId, DbType.String);
                parameters.Add("Status", tripmember.Status, DbType.Int32);
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> DeleteTripMemberByUserId(string userId)
        {
            try
            {
                var query = "DELETE FROM trip_member WHERE UserId = @UserId";

                var parameters = new DynamicParameters();
                parameters.Add("UserId", userId, DbType.String);
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> ConfirmTrip(int tripMemberId)
        {
            try
            {
                var query = "UPDATE trip_member SET " +
                    "Confirmation = 'Y' " +
                    "WHERE MemberId = @MemberId";

                var parameters = new DynamicParameters();
                parameters.Add("MemberId", tripMemberId, DbType.Int32);
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> UpdateSendMailDate(int id)
        {
            try
            {
                var query = "UPDATE trip_member SET " +
                    "SendDate = NOW() " +
                    "WHERE MemberId = @MemberId";

                var parameters = new DynamicParameters();
                parameters.Add("MemberId", id,  DbType.Int32);
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> DeleteTripMemberByTripId(string tripId)
        {
            try
            {
                var query = "DELETE FROM trip_member WHERE TripId = @TripId";

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

        public async Task<List<TripmemberVO>> GetAllTripMemberByEmailOrUsername(string memberName)
        {
            try
            {
                var parameters = new DynamicParameters();
                memberName ??= "";
                parameters.Add("NickName", memberName, DbType.String);

                var query = "SELECT * FROM user a LEFT JOIN user_detail b ON a.UserId = b.UserId WHERE LOWER(Username) LIKE CONCAT('%', LOWER(@NickName), '%') OR LOWER(Email) LIKE CONCAT('%', LOWER(@NickName), '%')  LIMIT 0, 20";

                using var connection = CreateConnection();
                return (await connection.QueryAsync<TripmemberVO>(query, parameters)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<List<TripmemberVO>> GetAllTripMemberUser(string tripId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("tripId", tripId, DbType.String);

                var query = "SELECT * FROM trip_member a LEFT JOIN user_detail b ON a.UserId = b.UserId LEFT JOIN user c ON a.UserId = c.UserId WHERE TripId = @tripId ";

                using var connection = CreateConnection();
                return (await connection.QueryAsync<TripmemberVO>(query, parameters)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<TripMemberDTO> GetTripMemberByEmail(string selectReceiver, string tripId)
        {
            try
            {
                var query = "SELECT * FROM trip_member a LEFT JOIN user_detail b ON a.UserId = b.UserId WHERE Email = @email AND TripId = @tripId";

                var parameters = new DynamicParameters();
                parameters.Add("email", selectReceiver, DbType.String);
                parameters.Add("tripId", tripId, DbType.String);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<TripMemberDTO>(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}
