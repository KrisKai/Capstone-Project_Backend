using Dapper;
using JourneySick.Data.Helpers;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace JourneySick.Data.IRepositories.Repositories
{
    public class TripRoleRepository : BaseRepository, ITripRoleRepository
    {
        public TripRoleRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<Tbltriprole>> GetAllTripRolesWithPaging(int pageIndex, int pageSize, string? roleName)
        {
            try
            {
                int firstIndex = pageIndex * pageSize;
                int lastIndex = (pageIndex + 1) * pageSize;
                roleName ??= "";
                var query = "SELECT * FROM tbltriprole WHERE fldRoleName LIKE CONCAT('%', @roleName, '%') LIMIT @firstIndex, @lastIndex";

                var parameters = new DynamicParameters();
                parameters.Add("firstIndex", firstIndex, DbType.Int16);
                parameters.Add("lastIndex", lastIndex, DbType.Int16);
                parameters.Add("roleName", roleName, DbType.String);

                using var connection = CreateConnection();
                return (await connection.QueryAsync<Tbltriprole>(query, parameters)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> GetLastOneId()
        {
            try
            {
                var query = "SELECT COALESCE(MAX(fldRoleId), 0) FROM tbltriprole ";
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<int>(query);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> CountAllTripRoles(string? roleName)
        {
            try
            {
                var query = "SELECT COUNT(*) FROM tbltriprole WHERE fldRoleName LIKE CONCAT('%', @roleName, '%')";
                roleName ??= "";
                var parameters = new DynamicParameters();
                parameters.Add("roleName", roleName, DbType.String);
                using var connection = CreateConnection();
                return ((int)(long)connection.ExecuteScalar(query, parameters));

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<Tbltriprole> GetTripRoleById(int roleId)
        {
            try
            {
                var query = "SELECT * FROM tbltriprole WHERE fldRoleId = @fldRoleId";

                var parameters = new DynamicParameters();
                parameters.Add("fldRoleId", roleId, DbType.Int32);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<Tbltriprole>(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        //CREATE
        public async Task<int> CreateTripRole(Tbltriprole tbltriprole)
        {
            try
            {
                var query = "INSERT INTO tbltriprole ("
                    //+ "         fldRoleId, "
                    + "         fldRoleName, "
                    + "         fldType, "
                    + "         fldDescription) "
                    + "     VALUES ( "
                    //+ "         @fldRoleId, "
                    + "         @fldRoleName, "
                    + "         @fldType, "
                    + "         @fldDescription) ";

                var parameters = new DynamicParameters();
                parameters.Add("fldRoleId", tbltriprole.FldRoleId, DbType.Int32);
                parameters.Add("fldRoleName", tbltriprole.FldRoleName, DbType.String);
                parameters.Add("fldType", tbltriprole.FldType, DbType.String);
                parameters.Add("fldDescription", tbltriprole.FldDescription, DbType.String);

                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query,parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> UpdateTripRole(Tbltriprole tbltriprole)
        {
            try
            {
                var query = "UPDATE tbltriprole SET"
                    + "         fldRoleName = @fldRoleName, "
                    + "         fldType = @fldType, "
                    + "         fldDescription = @fldDescription"
                    + "     WHERE fldRoleId = @fldRoleId"; ;

                var parameters = new DynamicParameters();
                parameters.Add("fldRoleId", tbltriprole.FldRoleId, DbType.Int32);
                parameters.Add("fldRoleName", tbltriprole.FldRoleName, DbType.String);
                parameters.Add("fldType", tbltriprole.FldType, DbType.String);
                parameters.Add("fldDescription", tbltriprole.FldDescription, DbType.String);

                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> DeleteTripRole(int roleId)
        {
            try
            {
                var query = "DELETE FROM tbltriprole WHERE fldRoleId = @fldRoleId";

                var parameters = new DynamicParameters();
                parameters.Add("fldRoleId", roleId, DbType.Int32);
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
