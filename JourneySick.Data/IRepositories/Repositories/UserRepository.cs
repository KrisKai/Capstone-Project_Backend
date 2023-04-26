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
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<TbluserVO>> GetAllUsersWithPaging(int pageIndex, int pageSize, string? userName, string role)
        {
            try
            {
                int firstIndex = pageIndex * pageSize;
                int lastIndex = (pageIndex + 1) * pageSize;
                userName ??= "";
                var query = "";
                if (role.Equals(UserRoleEnum.EMPL.ToString()))
                {
                    query = "SELECT a.fldUserId, fldUsername, fldFullname, fldRole, fldEmail, fldActiveStatus FROM tbluserdetail a INNER JOIN tbluser b ON a.fldUserId = b.fldUserId WHERE fldRole IN ('EMPL', 'USER') AND b.fldUsername LIKE CONCAT('%', @userName, '%') LIMIT @firstIndex, @lastIndex";
                }
                else if (role.Equals(UserRoleEnum.ADMIN.ToString()))
                {
                    query = "SELECT a.fldUserId, fldUsername, fldFullname, fldRole, fldEmail, fldActiveStatus FROM tbluserdetail a INNER JOIN tbluser b ON a.fldUserId = b.fldUserId WHERE b.fldUsername LIKE CONCAT('%', @userName, '%') LIMIT @firstIndex, @lastIndex";
                }
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

        public async Task<int> CountAllUsers(string? userName, string role)
        {
            try
            {
                var query = "";
                if (role.Equals(UserRoleEnum.EMPL.ToString()))
                {
                    query = "SELECT COUNT(*) FROM tbluserdetail a INNER JOIN tbluser b ON a.fldUserId = b.fldUserId WHERE fldRole IN ('EMPL', 'USER') AND b.fldUsername LIKE CONCAT('%', @userName, '%')";
                }
                else if (role.Equals(UserRoleEnum.ADMIN.ToString()))
                {
                    query = "SELECT COUNT(*) FROM tbluser WHERE fldUsername LIKE CONCAT('%', @userName, '%')";
                }
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
                var query = "SELECT COALESCE(MAX(fldUserId), null) FROM tbluser ";
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
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
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

        public async Task<int> ChangePassword(string? fldUserId, string newPassword)
        {
            try
            {
                var query = "UPDATE tbluser SET fldPassword = @fldPassword WHERE fldUserId = @fldUserId";

                var parameters = new DynamicParameters();
                parameters.Add("fldUserId", fldUserId, DbType.String);
                parameters.Add("fldPassword", newPassword, DbType.String);
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
