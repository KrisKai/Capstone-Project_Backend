using Dapper;
using JourneySick.Data.Helpers;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.VO;
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

        public async Task<int> CreateUserDetail(Tbluserdetail userDetail)
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
                    "fldExperience, " +
                    "fldTripCreated, " +
                    "fldTripJoined, " +
                    "fldTripCompleted, " +
                    "fldTripCancelled, " +
                    "fldCreateDate, " +
                    "fldCreateBy, " +
                    "fldUpdateDate, " +
                    "fldUpdateBy) " +
                    "VALUES " +
                    "(@fldUserId, " +
                    "@fldRole, " +
                    "@fldBirthday, " +
                    "@fldActiveStatus, " +
                    "@fldEmail, " +
                    "@fldFullname, " +
                    "@fldPhone, " +
                    "@fldAddress, " +
                    "@fldExperience, " +
                    "@fldTripCreated, " +
                    "@fldTripJoined, " +
                    "@fldTripCompleted, " +
                    "@fldTripCancelled, " +
                    "@fldCreateDate, " +
                    "@fldCreateBy, " +
                    "@fldUpdateDate, " +
                    "@fldUpdateBy);";

                var parameters = new DynamicParameters();
                parameters.Add("fldUserId", userDetail.FldUserId, DbType.String);
                parameters.Add("fldRole", userDetail.FldRole, DbType.String);
                parameters.Add("fldBirthday", userDetail.FldBirthday, DbType.DateTime);
                parameters.Add("fldActiveStatus", userDetail.FldActiveStatus, DbType.String);
                parameters.Add("fldEmail", userDetail.FldEmail, DbType.String);
                parameters.Add("fldFullname", userDetail.FldFullname, DbType.String);
                parameters.Add("fldPhone", userDetail.FldPhone, DbType.String);
                parameters.Add("fldAddress", userDetail.FldAddress, DbType.String);
                parameters.Add("fldExperience", userDetail.FldExperience, DbType.Double);
                parameters.Add("fldTripCreated", userDetail.FldTripCreated, DbType.Int16);
                parameters.Add("fldTripJoined", userDetail.FldTripJoined, DbType.Int16);
                parameters.Add("fldTripCompleted", userDetail.FldTripCompleted, DbType.Int16);
                parameters.Add("fldTripCancelled", userDetail.FldTripCancelled, DbType.Int16);
                parameters.Add("fldCreateDate", userDetail.FldCreateDate, DbType.DateTime);
                parameters.Add("fldCreateBy", userDetail.FldCreateBy, DbType.String);
                parameters.Add("fldUpdateDate", userDetail.FldUpdateDate, DbType.DateTime);
                parameters.Add("fldUpdateBy", userDetail.FldUpdateBy, DbType.String);
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<UserDetailDTO>> GetAllUsersWithPaging(int pageIndex, int pageSize)
        {
            try
            {
                int firstIndex = (pageIndex - 1) * pageSize;
                int lastIndex = pageIndex  * pageSize;
                var query = "SELECT * FROM tbluserdetail LIMIT @firstIndex, @lastIndex";

                var parameters = new DynamicParameters();
                parameters.Add("firstIndex", firstIndex, DbType.Int16);
                parameters.Add("lastIndex", lastIndex, DbType.Int16);

                using var connection = CreateConnection();
                return (await connection.QueryAsync<UserDetailDTO>(query, parameters)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        //SELECT
        public async Task<UserVO> GetUserDetailByUserName(String username)
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
        public async Task<List<Tbluserdetail>> GetUserList(Tbluserdetail userEntity)
        {
            try
            {
                var query = "SELECT * FROM tbluser WHERE fldUserId = @fldUserId";

                var parameters = new DynamicParameters();
                parameters.Add("fldUserId", userEntity.FldUserId, DbType.String);

                using var connection = CreateConnection();
                return (await connection.QueryAsync<Tbluserdetail>(query, parameters)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

/*        public async Task<string> GetUserRoleByUserId(string userId)
        {
            try
            {
                var query = "SELECT fldRole FROM tblUserDetail WHERE fldUserId = @fldUserId";
            }catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }*/
    }
}
