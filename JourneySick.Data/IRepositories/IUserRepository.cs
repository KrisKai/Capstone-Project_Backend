using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.VO;

namespace JourneySick.Data.IRepositories
{
    public interface IUserRepository
    {
        //CREATE
        public Task<int> CreateUser(Tbluser userEntity);
        public Task<string> GetLastOneId();
        public Task<string> GetUsernameIfExist(string username);
        public Task<string> GetPasswordByUsername(string username);
        public Task<UserVO> GetUserByUsername(string username);
        public Task<Tbluser> GetUserById(string userId);
        public Task<int> DeleteUser(string userId);
    }
}

