using JourneySick.Business.Models.DTOs;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.GetOneDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;

namespace JourneySick.Business.IServices
{
    public interface IUserService
    {
        Task<AllUserDTO> GetAllUsersWithPaging(int pageIndex, int pageSize, CurrentUserObj currentUser);
        //CREATE
        public Task<string> CreateAdmin(UserVO userDTO);
        public Task<string> CreateUser(UserVO userDTO);
        //UPDATE
        public Task<string> UpdateUser(UserVO userDTO);
        //SELECT BY ID
        public Task<UserVO> GetUserById(string userId);
        //DELETE
        public Task<int> DeleteUser(string id);
    }
}
