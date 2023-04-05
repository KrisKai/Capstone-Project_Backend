using JourneySick.Business.Models.DTOs;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Data.Models.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Business.IServices
{
    public interface IUserDetailService
    {
        //Select list
        public Task<AllUserDTO> GetAllUsersWithPaging(int pageIndex, int pageSize, CurrentUserObj currentUser);
        //Select User
        public Task<UserVO> GetUserDetailByUserName(String username);

    }
}
