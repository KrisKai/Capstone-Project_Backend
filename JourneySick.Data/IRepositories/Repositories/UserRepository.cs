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

        public async Task<List<Models.Entities.VO.UserVO>> GetAllUsersWithPaging(int pageIndex, int pageSize, string? userName, string role)
        {
            try
            {
                int firstIndex = pageIndex * pageSize;
                int lastIndex = (pageIndex + 1) * pageSize;
                userName ??= "";
                var query = "";
                if (role.Equals(UserRoleEnum.EMPL.ToString()))
                {
                    query = "SELECT a.UserId, Username, Fullname, Role, Email, ActiveStatus FROM userdetail a INNER JOIN user b ON a.UserId = b.UserId WHERE Role IN ('EMPL', 'USER') AND b.Username LIKE CONCAT('%', @userName, '%') LIMIT @firstIndex, @lastIndex";
                }
                else if (role.Equals(UserRoleEnum.ADMIN.ToString()))
                {
                    query = "SELECT a.UserId, Username, Fullname, Role, Email, ActiveStatus FROM userdetail a INNER JOIN user b ON a.UserId = b.UserId WHERE b.Username LIKE CONCAT('%', @userName, '%') LIMIT @firstIndex, @lastIndex";
                }
                var parameters = new DynamicParameters();
                parameters.Add("firstIndex", firstIndex, DbType.Int16);
                parameters.Add("lastIndex", lastIndex, DbType.Int16);
                parameters.Add("userName", userName, DbType.String);

                using var connection = CreateConnection();
                return (await connection.QueryAsync<Models.Entities.VO.UserVO>(query, parameters)).ToList();
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
                    query = "SELECT COUNT(*) FROM userdetail a INNER JOIN user b ON a.UserId = b.UserId WHERE Role IN ('EMPL', 'USER') AND b.Username LIKE CONCAT('%', @userName, '%')";
                }
                else if (role.Equals(UserRoleEnum.ADMIN.ToString()))
                {
                    query = "SELECT COUNT(*) FROM user WHERE Username LIKE CONCAT('%', @userName, '%')";
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
                var query = "SELECT COALESCE(MAX(UserId), null) FROM user ";
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
                var query = "SELECT Username FROM user WHERE Username = @Username";
                var parameters = new DynamicParameters();
                parameters.Add("Username", username, DbType.String);
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
                var query = "SELECT Password FROM User WHERE Username = @Username";
                var parameters = new DynamicParameters();
                parameters.Add("Username", username, DbType.String);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<string>(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<Models.Entities.VO.UserVO> GetUserByUsername(string username)
        {
            try
            {
                var query = "SELECT * FROM User a LEFT JOIN UserDetail b ON a.UserId = b.UserId WHERE Username = @Username AND ActiveStatus = 'ACTIVE'";
                var parameters = new DynamicParameters();
                parameters.Add("Username", username, DbType.String);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<Models.Entities.VO.UserVO>(query, parameters);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        //SELECT
        public async Task<Models.Entities.VO.UserVO> GetUserById(string userId)
        {
            try
            {
                var query = "SELECT * FROM user a JOIN UserDetail b ON a.UserId = b.UserId WHERE a.UserId = @UserId";

                var parameters = new DynamicParameters();
                parameters.Add("UserId", userId, DbType.String);

                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<Models.Entities.VO.UserVO>(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        //CREATE
        public async Task<int> CreateUser(Models.Entities.VO.UserVO userEntity)
        {
            try
            {
                var query = "INSERT INTO user ("
                    + "         UserId, "
                    + "         UserName, "
                    + "         Password) "
                    + "     VALUES ( "
                    + "         @UserId, "
                    + "         @UserName, "
                    + "         @Password)";

                var parameters = new DynamicParameters();
                parameters.Add("UserId", userEntity.UserId, DbType.String);
                parameters.Add("UserName", userEntity.Username, DbType.String);
                parameters.Add("Password", userEntity.Password, DbType.String);

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
                var query = "DELETE FROM user WHERE UserId = @UserId";

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

        public async Task<int> ChangePassword(string? UserId, string newPassword)
        {
            try
            {
                var query = "UPDATE user SET Password = @Password WHERE UserId = @UserId";

                var parameters = new DynamicParameters();
                parameters.Add("UserId", UserId, DbType.String);
                parameters.Add("Password", newPassword, DbType.String);
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
