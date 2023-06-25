using Dapper;
using Dapper.Transaction;
using JourneySick.Data.Helpers;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;
using JourneySick.Data.Models.Enums;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace JourneySick.Data.IRepositories.Repositories
{
    public class UserInterestRepository : BaseRepository, IUserInterestRepository
    {
        public UserInterestRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public async Task<List<UserInterest>> GetAllUserInterestsWithPaging(string userId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("userId", userId, DbType.String);

                var query = "SELECT * FROM user_interest WHERE UserId = @userId";

                using var connection = CreateConnection();
                return (await connection.QueryAsync<UserInterest>(query, parameters)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public Task<UserInterest> GetUserInterestById(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CountAllUserInterests(string userId)
        {
            try
            {
                var query = "SELECT COUNT(*) FROM user_interest WHERE UserId = @userId";

                var parameters = new DynamicParameters();
                parameters.Add("userId", userId, DbType.String);
                using var connection = CreateConnection();
                return ((int)(long)connection.ExecuteScalar(query, parameters));

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<long> CreateUserInterest(UserInterest userInterest)
        {
            try
            {
                long lastId;
                var query = "INSERT INTO user_interest ("
                    + "         UserId, "
                    + "         Interest) "
                    + "     VALUES ( "
                    + "         @UserId, "
                    + "         @Interest)";
                var getLastId = "SELECT LAST_INSERT_ID()";

                var parameters = new DynamicParameters();
                parameters.Add("UserId", userInterest.UserId, DbType.String);
                parameters.Add("Interest", userInterest.Interest, DbType.String);

                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using var transaction = connection.BeginTransaction();
                    transaction.Execute(query, parameters);
                    lastId = transaction.ExecuteScalar<long>(getLastId);
                    transaction.Commit();
                }
                return lastId;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> UpdateUserInterest(UserInterest userInterest)
        {

            try
            {
                var query = "UPDATE user_interest SET " +
                    "Interest = @Interest " +
                    "WHERE InterestId = @InterestId";

                var parameters = new DynamicParameters();
                parameters.Add("InterestId", userInterest.InterestId, DbType.Int32);
                parameters.Add("Interest", userInterest.Interest, DbType.String);
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
                var query = "DELETE FROM user_interest WHERE UserId = @userId";

                var parameters = new DynamicParameters();
                parameters.Add("userId", userId, DbType.String);
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<int> DeleteUserByInterestId(int interestId)
        {
            try
            {
                var query = "DELETE FROM user_interest WHERE InterestId = @interestId";

                var parameters = new DynamicParameters();
                parameters.Add("interestId", interestId, DbType.Int32);
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
