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
        public Task<Models.Entities.VO.UserVO> GetUserDetailById(string userId);
        public Task<Models.Entities.VO.UserVO> GetTripPresenterByTripId(string tripId);
        public Task<int> CreateUserDetail(Models.Entities.VO.UserVO userDetail);
        public Task<int> UpdateUserDetail(Models.Entities.VO.UserVO userDetailEntity);
        public Task<int> DeleteUserDetail(string userId);
        public Task<int> UpdateTripQuantityCreated(Models.Entities.VO.UserVO userDetailEntity);
        public Task<int> UpdateAcitveStatus(Models.Entities.VO.UserVO userDetailEntity);
    }
}
