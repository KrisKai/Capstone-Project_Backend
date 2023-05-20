using JourneySick.Data.Models.DTOs.CommonDTO.VO;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;

namespace JourneySick.Data.IRepositories
{
    public interface IUserRepository
    {

        public Task<List<UserVO>> GetAllUsersWithPaging(int pageIndex, int pageSize, string? userName, string role);

        public Task<int> CountAllUsers(string? userName, string role);

        public Task<string> GetLastOneId();

        public Task<string> GetUsernameIfExist(string username);

        public Task<string> GetPasswordByUsername(string username);

        public Task<UserVO> GetUserByUsername(string username);

        public Task<UserVO> GetUserById(string userId);

        //CREATE
        public Task<int> CreateUser(UserVO userEntity);

        //DELETE
        public Task<int> DeleteUser(string userId);

        public Task<int> ChangePassword(string? fldUserId, string newPassword);
        public Task<int> ConfirmUser(string id);
    }
}

