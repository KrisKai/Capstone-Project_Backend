using JourneySick.Data.Models.DTOs.CommonDTO.VO;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;

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

        public Task<TbluserVO> GetUserById(string userId);
        //DELETE
        public Task<int> DeleteUser(string userId);
    }
}

