using JourneySick.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.IRepositories
{
    public interface IUserRepository
    {
        //CREATE
        public Task<int> CreateUser(Tbluser userEntity);
        public Task<string> getLastOneId();
    }
}
