using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;
using JourneySick.Data.Models.VO;

namespace JourneySick.Data.IRepositories
{
    public interface IUserDetailRepository
    {
        public Task<int> CountAllUsers();
        public Task<int> CreateUserDetail(Tbluserdetail userDetail);
        public Task<List<TbluserVO>> GetAllUsersWithPaging(int pageIndex, int pageSize);
        //Select User Detail
        public Task<UserVO> GetUserDetailByUserName(String username);
        public Task<int> UpdateUserDetail(Tbluserdetail userDetailEntity);
    }
}
