using JourneySick.Data.Models.Entities.VO;

namespace JourneySick.Data.IRepositories
{
    public interface IUserDetailRepository
    {
        public Task<string> GetEmailIfExist(string email);
        public Task<string> GetPhoneIfExist(string phone);
        public Task<UserVO> GetUserDetailById(string userId);
        public Task<UserVO> GetUserDetailByEmail(string userId);
        public Task<UserVO> GetTripPresenterByTripId(string tripId);
        public Task<int> CreateUserDetail(UserVO userDetail);
        public Task<int> UpdateUserDetail(UserVO userDetailEntity);
        public Task<int> DeleteUserDetail(string userId);
        public Task<int> UpdateTripQuantityCreated(UserVO userDetailEntity);
        public Task<int> UpdateAcitveStatus(UserVO userDetailEntity);
    }
}
