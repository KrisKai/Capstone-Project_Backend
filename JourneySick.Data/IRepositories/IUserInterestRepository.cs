using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;

namespace JourneySick.Data.IRepositories
{
    public interface IUserInterestRepository
    {
        public Task<List<UserInterest>> GetAllUserInterests(string userId);

        public Task<int> CountAllUserInterests(string userId);

        public Task<UserInterest> GetUserInterestById(int interestId);

        //CREATE
        public Task<long> CreateUserInterest(UserInterest userInterest);

        //CREATE
        public Task<int> UpdateUserInterest(UserInterest userInterest);

        //DELETE
        public Task<int> DeleteUserInterest(string userId);
        //DELETE
        public Task<int> DeleteUserInterestByInterestId(int interestId);
    }
}
