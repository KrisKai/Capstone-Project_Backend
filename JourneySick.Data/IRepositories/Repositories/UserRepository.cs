using Dapper;
using JourneySick.Data.Helpers;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;

namespace JourneySick.Data.IRepositories.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<TbluserVO>> GetAllUsersWithPaging(int pageIndex, int pageSize, string? userName)
        {
            try
            {
                int firstIndex = pageIndex * pageSize;
                int lastIndex = (pageIndex + 1) * pageSize;
                userName ??= "";
                var query = "SELECT * FROM tbluserdetail a INNER JOIN tbluser b ON a.fldUserId = b.fldUserId WHERE b.fldUsername LIKE CONCAT('%', @userName, '%') LIMIT @firstIndex, @lastIndex";

                var parameters = new DynamicParameters();
                parameters.Add("firstIndex", firstIndex, DbType.Int16);
                parameters.Add("lastIndex", lastIndex, DbType.Int16);
                parameters.Add("userName", userName, DbType.String);

                using var connection = CreateConnection();
                return (await connection.QueryAsync<TbluserVO>(query, parameters)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> CountAllUsers(string? userName)
        {
            try
            {
                var query = "SELECT COUNT(*) FROM tbluser WHERE fldUsername LIKE CONCAT('%', @userName, '%')";
                userName ??= "";
                var parameters = new DynamicParameters();
                parameters.Add("userName", userName, DbType.String);
                using var connection = CreateConnection();
                return ((int)(long)connection.ExecuteScalar(query, parameters));

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
                var query = "SELECT COALESCE(MAX(fldUserId), 0) FROM tbluser ";
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<string>(query);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<string> GetUsernameIfExist(string username)
        {
            try
            {
                var query = "SELECT fldUsername FROM tbluser WHERE fldUsername = @fldUsername";
                var parameters = new DynamicParameters();
                parameters.Add("fldUsername", username, DbType.String);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<string>(query, parameters);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<string> GetPasswordByUsername(string username)
        {
            try
            {
                var query = "SELECT fldPassword FROM tblUser WHERE fldUsername = @fldUsername";
                var parameters = new DynamicParameters();
                parameters.Add("fldUsername", username, DbType.String);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<string>(query, parameters);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<TbluserVO> GetUserByUsername(string username)
        {
            try
            {
                var query = "SELECT * FROM tblUser a LEFT JOIN tblUserDetail b ON a.fldUserId = b.fldUserId WHERE fldUsername = @fldUsername";
                var parameters = new DynamicParameters();
                parameters.Add("fldUsername", username, DbType.String);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<TbluserVO>(query, parameters);

            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        //SELECT
        public async Task<TbluserVO> GetUserById(string userId)
        {
            try
            {
                var query = "SELECT * FROM tbluser a JOIN tblUserDetail b ON a.fldUserId = b.fldUserId WHERE a.fldUserId = @fldUserId";

                var parameters = new DynamicParameters();
                parameters.Add("fldUserId", userId, DbType.String);

                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<TbluserVO>(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        //CREATE
        public async Task<int> CreateUser(TbluserVO userEntity)
        {
            try
            {
                var query = "INSERT INTO tbluser ("
                    + "         fldUserId, "
                    + "         fldUserName, "
                    + "         fldPassword) "
                    + "     VALUES ( "
                    + "         @fldUserId, "
                    + "         @fldUserName, "
                    + "         @fldPassword)";

                var parameters = new DynamicParameters();
                parameters.Add("fldUserId", userEntity.FldUserId, DbType.String);
                parameters.Add("fldUserName", userEntity.FldUsername, DbType.String);
                parameters.Add("fldPassword", userEntity.FldPassword, DbType.String);

                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }


        public async Task<int> DeleteUser(string userId)
        {
            try
            {
                var query = "DELETE FROM tbluser WHERE fldUserId = @fldUserId";

                var parameters = new DynamicParameters();
                parameters.Add("fldUserId", userId, DbType.String);
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
