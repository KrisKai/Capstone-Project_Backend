using Dapper;
using JourneySick.Data.Helpers;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.Request;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.IRepositories.Repositories
{
    public class UserDetailRepository : BaseRepository, IUserDetailRepository
    {
        public UserDetailRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public async Task<string> GetEmailIfExist(string email)
        {
            try
            {
                var query = "SELECT Email FROM user_detail WHERE Email = @Email";
                var parameters = new DynamicParameters();
                parameters.Add("Email", email, DbType.String);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<string>(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<string> GetPhoneIfExist(string phone)
        {
            try
            {
                var query = "SELECT Phone FROM user_detail WHERE Phone = @Phone";
                var parameters = new DynamicParameters();
                parameters.Add("Phone", phone, DbType.String);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<string>(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<UserVO> GetUserDetailById(string userId)
        {
            try
            {
                var query = "SELECT * FROM user_detail WHERE UserId = @UserId";
                var parameters = new DynamicParameters();
                parameters.Add("UserId", userId, DbType.String);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<UserVO>(query, parameters);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<UserVO> GetTripPresenterByTripId(string tripId)
        {
            try
            {
                var query = "SELECT * FROM user_detail a RIGHT JOIN trip b ON a.UserId = b.TripPresenter WHERE TripId = @TripId";
                var parameters = new DynamicParameters();
                parameters.Add("TripId", tripId, DbType.String);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<UserVO>(query, parameters);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        //SELECT
        public async Task<UserRequest> GetUserDetailByUserName(string username)
        {
            try
            {
                var query = "SELECT a.Birthday, " +
                    "a.ActiveStatus, " +
                    "a.Email, " +
                    "a.Fullname, " +
                    "a.Phone, " +
                    "a.Address, " +
                    "a.Experience, " +
                    "a.TripCreated, " +
                    "a.TripJoined, " +
                    "a.TripCompleted, " +
                    "a.TripCancelled, " +
                    "a.CreateDate, " +
                    "a.CreateBy, " +
                    "a.UpdateDate, " +
                    "a.UpdateBy  FROM user_detail a JOIN user b ON a.UserId = b.UserId WHERE Username = @Username";

                var parameters = new DynamicParameters();
                parameters.Add("Username", username, DbType.String);

                using var connection = CreateConnection();
                return (await connection.QueryFirstOrDefaultAsync<UserRequest>(query));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        //SELECT
        public async Task<List<UserVO>> GetUserList(UserVO userEntity)
        {
            try
            {
                var query = "SELECT * FROM user WHERE UserId = @UserId";

                var parameters = new DynamicParameters();
                parameters.Add("UserId", userEntity.UserId, DbType.String);

                using var connection = CreateConnection();
                return (await connection.QueryAsync<UserVO>(query, parameters)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> CreateUserDetail(UserVO userDetail)
        {
            try
            {
                var query = "INSERT INTO user_detail " +
                    "(UserId, " +
                    "Role, " +
                    "Birthday, " +
                    "ActiveStatus, " +
                    "Email, " +
                    "Fullname, " +
                    "Phone, " +
                    "Address, " +
                    "CreateDate, " +
                    "CreateBy) " +
                    "VALUES " +
                    "(@UserId, " +
                    "@Role, " +
                    "@Birthday, " +
                    "@ActiveStatus, " +
                    "@Email, " +
                    "@Fullname, " +
                    "@Phone, " +
                    "@Address," +
                    "@CreateDate, " +
                    "@CreateBy);";

                var parameters = new DynamicParameters();
                parameters.Add("UserId", userDetail.UserId, DbType.String);
                parameters.Add("Role", userDetail.Role, DbType.String);
                parameters.Add("Birthday", userDetail.Birthday, DbType.DateTime);
                parameters.Add("ActiveStatus", userDetail.ActiveStatus, DbType.String);
                parameters.Add("Email", userDetail.Email, DbType.String);
                parameters.Add("Fullname", userDetail.Fullname, DbType.String);
                parameters.Add("Phone", userDetail.Phone, DbType.String);
                parameters.Add("Address", userDetail.Address, DbType.String);
                parameters.Add("CreateDate", userDetail.CreateDate, DbType.DateTime);
                parameters.Add("CreateBy", userDetail.CreateBy, DbType.String);
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> UpdateUserDetail(UserVO userDetailEntity)
        {
            try
            {
                var query = "UPDATE user_detail SET " +
                    "Birthday = @Birthday, " +
                    "Email = @Email, " +
                    "Fullname = @Fullname, " +
                    "Phone = @Phone, " +
                    "Address = @Address, " +
                    "UpdateDate = @UpdateDate, " +
                    "UpdateBy = @UpdateBy " +
                    "WHERE UserId = @UserId";

                var parameters = new DynamicParameters();
                parameters.Add("UserId", userDetailEntity.UserId, DbType.String);
                parameters.Add("Birthday", userDetailEntity.Birthday, DbType.DateTime);
                parameters.Add("Email", userDetailEntity.Email, DbType.String);
                parameters.Add("Fullname", userDetailEntity.Fullname, DbType.String);
                parameters.Add("Phone", userDetailEntity.Phone, DbType.String);
                parameters.Add("Address", userDetailEntity.Address, DbType.String);
                parameters.Add("UpdateDate", userDetailEntity.UpdateDate, DbType.DateTime);
                parameters.Add("UpdateBy", userDetailEntity.UpdateBy, DbType.String);
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);

            }
            catch(Exception e) 
            { 
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> UpdateAcitveStatus(UserVO userDetailEntity)
        {
            try
            {
                var query = "UPDATE user_detail SET " +
                    "ActiveStatus = @ActiveStatus " +
                    "WHERE UserId = @UserId";

                var parameters = new DynamicParameters();
                parameters.Add("UserId", userDetailEntity.UserId, DbType.String);
                parameters.Add("ActiveStatus", userDetailEntity.ActiveStatus, DbType.String);
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> UpdateTripQuantityCreated(UserVO userDetailEntity)
        {
            try
            {
                var query = "UPDATE user_detail SET " +
                    "TripCreated = @TripCreated " +
                    "WHERE UserId = @UserId";

                var parameters = new DynamicParameters();
                parameters.Add("UserId", userDetailEntity.UserId, DbType.String);
                parameters.Add("TripCreated", userDetailEntity.TripCreated, DbType.Int32);
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> DeleteUserDetail(string userId)
        {
            try
            {
                var query = "DELETE FROM user_detail WHERE UserId = @UserId";

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
    }
}
