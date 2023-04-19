using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;

namespace JourneySick.Data.IRepositories
{
    public interface IUserDetailRepository
    {
        public Task<string> GetEmailIfExist(string email);
        public Task<string> GetPhoneIfExist(string phone);
        public Task<TbluserVO> GetUserDetailById(string userId);
        public Task<int> CreateUserDetail(TbluserVO userDetail);
        public Task<int> UpdateUserDetail(TbluserVO userDetailEntity);
        public Task<int> DeleteUserDetail(string userId);
        public Task<int> UpdateTripQuantityCreated(TbluserVO userDetailEntity);
    }
}
