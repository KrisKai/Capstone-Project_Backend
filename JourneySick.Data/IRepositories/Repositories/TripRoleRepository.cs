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

        public async Task<List<TripRole>> GetAllTripRolesWithPaging(int pageIndex, int pageSize, string? roleName)
        {
            try
            {
                int firstIndex = pageIndex * pageSize;
                int lastIndex = (pageIndex + 1) * pageSize;
                roleName ??= "";
                var query = "SELECT * FROM triprole WHERE RoleName LIKE CONCAT('%', @roleName, '%') LIMIT @firstIndex, @lastIndex";

                var parameters = new DynamicParameters();
                parameters.Add("firstIndex", firstIndex, DbType.Int16);
                parameters.Add("lastIndex", lastIndex, DbType.Int16);
                parameters.Add("roleName", roleName, DbType.String);

                using var connection = CreateConnection();
                return (await connection.QueryAsync<TripRole>(query, parameters)).ToList();
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
                var query = "SELECT COUNT(*) FROM triprole WHERE RoleName LIKE CONCAT('%', @roleName, '%')";
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

        public async Task<TripRole> GetTripRoleById(int roleId)
        {
            try
            {
                var query = "SELECT * FROM triprole WHERE RoleId = @RoleId";

                var parameters = new DynamicParameters();
                parameters.Add("RoleId", roleId, DbType.Int32);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<TripRole>(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        //CREATE
        public async Task<int> CreateTripRole(TripRole triprole)
        {
            try
            {
                var query = "INSERT INTO triprole ("
                    + "         RoleName, "
                    + "         Type, "
                    + "         Description) "
                    + "     VALUES ( "
                    + "         @RoleName, "
                    + "         @Type, "
                    + "         @Description) ";

                var parameters = new DynamicParameters();
                parameters.Add("RoleId", triprole.RoleId, DbType.Int32);
                parameters.Add("RoleName", triprole.RoleName, DbType.String);
                parameters.Add("Type", triprole.Type, DbType.String);
                parameters.Add("Description", triprole.Description, DbType.String);

                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query,parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> UpdateTripRole(TripRole triprole)
        {
            try
            {
                var query = "UPDATE triprole SET"
                    + "         RoleName = @RoleName, "
                    + "         Type = @Type, "
                    + "         Description = @Description"
                    + "     WHERE RoleId = @RoleId"; ;

                var parameters = new DynamicParameters();
                parameters.Add("RoleId", triprole.RoleId, DbType.Int32);
                parameters.Add("RoleName", triprole.RoleName, DbType.String);
                parameters.Add("Type", triprole.Type, DbType.String);
                parameters.Add("Description", triprole.Description, DbType.String);

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
                var query = "DELETE FROM triprole WHERE RoleId = @RoleId";

                var parameters = new DynamicParameters();
                parameters.Add("RoleId", roleId, DbType.Int32);
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
