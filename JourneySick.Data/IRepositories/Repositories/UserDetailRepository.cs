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
                var query = "SELECT fldEmail FROM tbluserdetail WHERE fldEmail = @fldEmail";
                var parameters = new DynamicParameters();
                parameters.Add("fldEmail", email, DbType.String);
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
                var query = "SELECT fldPhone FROM tbluserdetail WHERE fldPhone = @fldPhone";
                var parameters = new DynamicParameters();
                parameters.Add("fldPhone", phone, DbType.String);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<string>(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<TbluserVO> GetUserDetailById(string userId)
        {
            try
            {
                var query = "SELECT * FROM tbluserdetail WHERE fldUserId = @fldUserId";
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

        public async Task<int> CreateUserDetail(TbluserVO userDetail)
        {
            try
            {
                var query = "INSERT INTO tbluserdetail " +
                    "(fldUserId, " +
                    "fldRole, " +
                    "fldBirthday, " +
                    "fldActiveStatus, " +
                    "fldEmail, " +
                    "fldFullname, " +
                    "fldPhone, " +
                    "fldAddress, " +
                    "fldCreateDate, " +
                    "fldCreateBy) " +
                    "VALUES " +
                    "(@fldUserId, " +
                    "@fldRole, " +
                    "@fldBirthday, " +
                    "@fldActiveStatus, " +
                    "@fldEmail, " +
                    "@fldFullname, " +
                    "@fldPhone, " +
                    "@fldAddress," +
                    "@fldCreateDate, " +
                    "@fldCreateBy);";

                var parameters = new DynamicParameters();
                parameters.Add("fldUserId", userDetail.FldUserId, DbType.String);
                parameters.Add("fldRole", userDetail.FldRole, DbType.String);
                parameters.Add("fldBirthday", userDetail.FldBirthday, DbType.DateTime);
                parameters.Add("fldActiveStatus", userDetail.FldActiveStatus, DbType.String);
                parameters.Add("fldEmail", userDetail.FldEmail, DbType.String);
                parameters.Add("fldFullname", userDetail.FldFullname, DbType.String);
                parameters.Add("fldPhone", userDetail.FldPhone, DbType.String);
                parameters.Add("fldAddress", userDetail.FldAddress, DbType.String);
                parameters.Add("fldCreateDate", userDetail.FldCreateDate, DbType.DateTime);
                parameters.Add("fldCreateBy", userDetail.FldCreateBy, DbType.String);        
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> DeleteUserDetail(string userId)
        {
            try
            {
                var query = "DELETE FROM tbluserdetail WHERE fldUserId = @fldUserId";

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

        //SELECT
        public async Task<UserVO> GetUserDetailByUserName(string username)
        {
            try
            {
                var query = "SELECT a.fldBirthday, " +
                    "a.fldActiveStatus, " +
                    "a.fldEmail, " +
                    "a.fldFullname, " +
                    "a.fldPhone, " +
                    "a.fldAddress, " +
                    "a.fldExperience, " +
                    "a.fldTripCreated, " +
                    "a.fldTripJoined, " +
                    "a.fldTripCompleted, " +
                    "a.fldTripCancelled, " +
                    "a.fldCreateDate, " +
                    "a.fldCreateBy, " +
                    "a.fldUpdateDate, " +
                    "a.fldUpdateBy  FROM tbluserdetail a JOIN tbluser b ON a.fldUserId = b.fldUserId WHERE fldUsername = @fldUsername";

                var parameters = new DynamicParameters();
                parameters.Add("fldUsername", username, DbType.String);

                using var connection = CreateConnection();
                return (await connection.QueryFirstOrDefaultAsync<UserVO>(query));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        //SELECT
        public async Task<List<TbluserVO>> GetUserList(TbluserVO userEntity)
        {
            try
            {
                var query = "SELECT * FROM tbluser WHERE fldUserId = @fldUserId";

                var parameters = new DynamicParameters();
                parameters.Add("fldUserId", userEntity.FldUserId, DbType.String);

                using var connection = CreateConnection();
                return (await connection.QueryAsync<TbluserVO>(query, parameters)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> UpdateUserDetail(TbluserVO userDetailEntity)
        {
            try
            {
                var query = "UPDATE tbluserdetail SET " +
                    "fldBirthday = @Birthday, " +
                    "fldEmail = @Email, " +
                    "fldFullname = @Fullname, " +
                    "fldPhone = @Phone, " +
                    "fldAddress = @Address, " +
                    "fldActiveStatus = @Status, " +
                    "fldUpdateDate = @UpdateDate, " +
                    "fldUpdateBy = @UpdateBy " +
                    "WHERE fldUserId = @UserId";

                var parameters = new DynamicParameters();
                parameters.Add("UserId", userDetailEntity.FldUserId, DbType.String);
                parameters.Add("Birthday", userDetailEntity.FldBirthday, DbType.DateTime);
                parameters.Add("Email", userDetailEntity.FldEmail, DbType.String);
                parameters.Add("Fullname", userDetailEntity.FldFullname, DbType.String);
                parameters.Add("Phone", userDetailEntity.FldPhone, DbType.String);
                parameters.Add("Address", userDetailEntity.FldAddress, DbType.String);
                parameters.Add("Status", userDetailEntity.FldActiveStatus, DbType.String);
                parameters.Add("UpdateDate", userDetailEntity.FldUpdateDate, DbType.DateTime);
                parameters.Add("UpdateBy", userDetailEntity.FldUpdateBy, DbType.String);
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);

            }
            catch(Exception e) 
            { 
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> UpdateTripQuantityCreated(TbluserVO userDetailEntity)
        {
            try
            {
                var query = "UPDATE tbluserdetail SET " +
                    "fldTripCreated = @fldTripCreated, " +
                    "WHERE fldUserId = @UserId";

                var parameters = new DynamicParameters();
                parameters.Add("UserId", userDetailEntity.FldUserId, DbType.String);
                parameters.Add("fldTripCreated", userDetailEntity.FldTripCreated, DbType.Int32);
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
