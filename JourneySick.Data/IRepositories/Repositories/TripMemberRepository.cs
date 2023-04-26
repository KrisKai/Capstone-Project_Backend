using Dapper;
using JourneySick.Data.Helpers;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Numerics;

namespace JourneySick.Data.IRepositories.Repositories
{
    public class TripMemberRepository : BaseRepository, ITripMemberRepository
    {
        public TripMemberRepository(IConfiguration configuration) : base(configuration)
        {
        }


        public async Task<int> GetLastOneId()
        {
            try
            {
                var query = "SELECT COALESCE(MAX(fldUserId), 0) FROM tbltripmember ";
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<int>(query);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<TbltripmemberVO> GetTripMemberById(int memberId)
        {
            try
            {
                var query = "SELECT * FROM tbltripmember a INNER JOIN tbluserdetail b ON a.fldUserId = b.fldUserId WHERE fldMemberId = @fldMemberId";

                var parameters = new DynamicParameters();
                parameters.Add("fldMemberId", memberId, DbType.Int16);
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<TbltripmemberVO>(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<List<TbltripmemberVO>> GetAllTripMembersWithPaging(int pageIndex, int pageSize, string? memberName)
        {
            try
            {
                int firstIndex = (pageIndex) * pageSize;
                int lastIndex = (pageIndex + 1) * pageSize;
                var parameters = new DynamicParameters();
                parameters.Add("firstIndex", firstIndex, DbType.Int16);
                parameters.Add("lastIndex", lastIndex, DbType.Int16);
                memberName ??= "";
                parameters.Add("fldNickName", memberName, DbType.String);

                var query = "SELECT * FROM tbltripmember a INNER JOIN tbluserdetail b ON a.fldUserId = b.fldUserId INNER JOIN tbltriprole c ON a.fldMemberRoleId = c.fldRoleId WHERE fldNickName LIKE CONCAT('%', @fldNickName, '%')  LIMIT @firstIndex, @lastIndex";

                using var connection = CreateConnection();
                return (await connection.QueryAsync<TbltripmemberVO>(query, parameters)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public async Task<int> CountAllTripMembers(string? memberName)
        {
            try
            {
                var query = "SELECT COUNT(*) FROM tbltripmember WHERE fldNickName LIKE CONCAT('%', @fldNickName, '%')";

                memberName ??= "";
                var parameters = new DynamicParameters();
                parameters.Add("fldNickName", memberName, DbType.String);
                using var connection = CreateConnection();
                return ((int)(long)connection.ExecuteScalar(query, parameters));

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> CreateTripMember(Tbltripmember tbltripmember)
        {
            try
            {
                var query = "INSERT INTO tbltripmember ("
                    + "         fldUserId, "
                    + "         fldTripId, "
                    + "         fldMemberRoleId, "
                    + "         fldNickName, "
                    + "         fldStatus, "
                    + "         fldCreateDate, "
                    + "         fldCreateBy) "
                    + "     VALUES ( "
                    + "         @fldUserId, "
                    + "         @fldTripId, "
                    + "         @fldMemberRoleId, "
                    + "         @fldNickName, "
                    + "         @fldStatus, "
                    + "         @fldCreateDate, "
                    + "         @fldCreateBy)";

                var parameters = new DynamicParameters();
                parameters.Add("fldUserId", tbltripmember.FldUserId, DbType.String);
                parameters.Add("fldTripId", tbltripmember.FldTripId, DbType.String);
                parameters.Add("fldMemberRoleId", tbltripmember.FldMemberRoleId, DbType.Int32);
                parameters.Add("fldNickName", tbltripmember.FldNickName, DbType.String);
                parameters.Add("fldStatus", tbltripmember.FldStatus, DbType.String);
                parameters.Add("fldCreateDate", tbltripmember.FldCreateDate, DbType.DateTime);
                parameters.Add("fldCreateBy", tbltripmember.FldCreateBy, DbType.String);

                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> UpdateTripMember(Tbltripmember tbltripmember)
        {
            try
            {
                var query = "UPDATE tbltripmember SET " +
                    "fldUserId = @fldUserId, " +
                    "fldTripId = @fldTripId, " +
                    "fldMemberRoleId = @fldMemberRoleId, " +
                    "fldNickName = @fldNickName, " +
                    "fldStatus = @fldStatus, " +
                    "fldUpdateDate = @fldUpdateDate, " +
                    "fldUpdateBy = @fldUpdateBy " +
                    "WHERE fldMemberId = @fldMemberId";

                var parameters = new DynamicParameters();
                parameters.Add("fldMemberId", tbltripmember.FldMemberId, DbType.Int32);
                parameters.Add("fldUserId", tbltripmember.FldUserId, DbType.String);
                parameters.Add("fldTripId", tbltripmember.FldTripId, DbType.String);
                parameters.Add("fldMemberRoleId", tbltripmember.FldMemberRoleId, DbType.Int32);
                parameters.Add("fldNickName", tbltripmember.FldNickName, DbType.String);
                parameters.Add("fldStatus", tbltripmember.FldStatus, DbType.String);
                parameters.Add("fldUpdateDate", tbltripmember.FldUpdateDate, DbType.DateTime);
                parameters.Add("fldUpdateBy", tbltripmember.FldUpdateBy, DbType.String);
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }


        public async Task<int> DeleteTripMember(int planDetailId)
        {
            try
            {
                var query = "DELETE FROM tbltripmember WHERE fldMemberId = @fldMemberId";

                var parameters = new DynamicParameters();
                parameters.Add("fldMemberId", planDetailId, DbType.Int32);
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
