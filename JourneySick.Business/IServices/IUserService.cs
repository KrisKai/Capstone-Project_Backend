using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.VO;

namespace JourneySick.Business.IServices
{
    public interface IUserService
    {
        //CREATE
        public Task<string> CreateUser(UserVO userDTO);
        //UPDATE
        public Task<string> UpdateUser(UserVO userDTO);

        public Task<UserVO> GetUserById(string userId);
    }
}
