using Dapper;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Repositories.Helpers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Repositories.ImplRepositories
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
    }
}
