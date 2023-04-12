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
        public Task<int> GetLastOneId();
        public Task<Tbltriprole> GetTripRoleById(string roleId);
        public Task<List<Tbltriprole>> GetAllTripRolesWithPaging(int pageIndex, int pageSize, string? roleName);
        public Task<int> CountAllTripRoles(string? roleName);
        //CREATE
        public Task<int> CreateTripRole(Tbltriprole tbltriprole);
        //UPDATE
        public Task<int> UpdateTripRole(Tbltriprole tbltriprole);
        //DELETE
        public Task<int> DeleteTripRole(int roleId);
    }
}
