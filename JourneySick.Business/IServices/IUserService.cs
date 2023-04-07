using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.VO;

namespace JourneySick.Business.IServices
{
    public interface IUserService
    {
        //CREATE
        public Task<string> CreateAdmin(UserVO userDTO);
        public Task<string> CreateUser(UserDTO userDTO);
        //UPDATE
        public Task<string> UpdateUser(UserVO userDTO);

        public Task<UserDTO> GetUserById(String userId);
    }
}
