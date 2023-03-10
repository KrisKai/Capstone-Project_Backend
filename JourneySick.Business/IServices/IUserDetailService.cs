﻿using JourneySick.Data.Models.DTOs;
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
        public Task<string> GetAllUsersWithPaging();
        //Select User
        public Task<UserVO> GetUserDetailByUserName(String username);

    }
}
