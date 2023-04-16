using JourneySick.Business.Models.DTOs;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;

namespace JourneySick.Business.IServices
{
    public interface IUserService
    {
        public Task<AllUserDTO> GetAllUsersWithPaging(int pageIndex, int pageSize, string? userName, CurrentUserObj currentUser);
        //CREATE
        public Task<string> CreateUser(UserVO userDTO, CurrentUserObj currentUser);
        //UPDATE
        public Task<string> UpdateUser(UserVO userDTO, CurrentUserObj currentUser);
        //SELECT BY ID
        public Task<UserVO> GetUserById(string userId);
        //DELETE
        public Task<int> DeleteUser(string id);
        public Task<int> ResetPassword(string? id, CurrentUserObj currentUser);
        public Task<int> ChangePassword(string? fldUserId, string? fldOldPassword, string? fldPassword);
    }
}
