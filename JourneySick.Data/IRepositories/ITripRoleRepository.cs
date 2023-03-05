using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.IRepositories
{
    public interface ITripRoleRepository
    {
        //CREATE
        public Task<int> CreateTripRole(Tbltriprole tbltriprole);
        //UPDATE
        public Task<int> UpdateTripRole(Tbltriprole tbltriprole);
        //DELETE
        public Task<int> DeleteTripRole(int roleId);
        public Task<int> GetLastOneId();
        public Task<Tbltriprole> SelectTripRole(int roleId);
    }
}
