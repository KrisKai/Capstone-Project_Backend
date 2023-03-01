using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
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
        public Task<List<UserDetailDTO>> SelectAllUsersWithPaging(int pageIndex, int pageSize);
    }
}
