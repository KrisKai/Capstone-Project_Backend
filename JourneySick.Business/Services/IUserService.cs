using JourneySick.Data.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Business.Services
{
    public interface IUserService
    {
        //CREATE
        public Task<int> CreateUser(UserDTO userDTO);
    }
}
