using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.VO;

namespace JourneySick.Business.IServices
{
    public interface IUserService
    {
        //CREATE
        public Task<int> CreateUser(UserVO userDTO);
        //UPDATE
        public Task<string> UpdateUser(UserVO userDTO);
        //SELECT BY ID
        public Task<UserVO> GetUserById(string userId);
        //DELETE
        public Task<int> DeleteUser(string id);
    }
}
