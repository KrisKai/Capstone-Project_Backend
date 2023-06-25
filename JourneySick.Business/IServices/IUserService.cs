using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.Request;

namespace JourneySick.Business.IServices
{
    public interface IUserService
    {
        public Task<AllUserDTO> GetAllUsersWithPaging(int pageIndex, int pageSize, string? userName, CurrentUserObject currentUser);
        //CREATE
        public Task<string> CreateUser(UserRequest userDTO, CurrentUserObject currentUser);
        //UPDATE
        public Task<string> UpdateUser(UserRequest userDTO, CurrentUserObject currentUser);
        //SELECT BY ID
        public Task<UserRequest> GetUserById(string userId);
        //DELETE
        public Task<int> DeleteUser(string id);
        public Task<int> ResetPassword(string? id, CurrentUserObject currentUser);
        public Task<int> ChangePassword(ChangePasswordRequest changePasswordDTO);
        public Task<int> UpdateAcitveStatus(UserRequest userDTO, CurrentUserObject currentUser);
        public Task<string> ConfirmUser(string id);
        public Task<int> CheckUserHavingInterest(string id);
        public Task<AllUserDTO> GetAllUserInterestsWithPaging(CurrentUserObject currentUser);
    }
}
