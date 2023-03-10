using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.IRepositories
{
    public interface IUserDetailRepository
    {
        public Task<int> CreateUserDetail(Tbluserdetail userDetail);
        //Select list
        public Task<List<UserDetailDTO>> GetAllUsersWithPaging(int pageIndex, int pageSize);
        //Select User Detail
        public Task<UserVO> GetUserDetailByUserName(String username);
    }
}
