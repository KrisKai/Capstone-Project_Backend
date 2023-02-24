using Dapper;
using JourneySick.Data.Helpers;
using JourneySick.Data.Models.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace JourneySick.Data.IRepositories.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
        }

        //CREATE
        public async Task<int> CreateUser(Tbluser userEntity)
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

        public async Task<string> getLastOneId()
        {
            try
            {
                var query = "SELECT MAX(fldUserId) FROM tbluser ";
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<string>(query);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        //SELECT
        public async Task<List<Tbluser>> SelectUser(Tbluser userEntity)
        {
            try
            {
                var query = "SELECT * FROM tbluser WHERE fldUserId = @fldUserId";

                var parameters = new DynamicParameters();
                parameters.Add("fldUserId", userEntity.FldUserId, DbType.String);

                using var connection = CreateConnection();
                return (await connection.QueryAsync<Tbluser>(query, parameters)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}
