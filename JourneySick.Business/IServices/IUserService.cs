using JourneySick.Data.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Business.IServices
{
    public interface IUserService
    {
        //CREATE
        public Task<string> CreateUser(UserDTO userDTO);
    }
}
