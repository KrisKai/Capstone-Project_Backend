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
        public Task<TripRole> GetTripRoleById(int roleId);
        public Task<List<TripRole>> GetAllTripRolesWithPaging(int pageIndex, int pageSize, string? roleName);
        public Task<int> CountAllTripRoles(string? roleName);
        //CREATE
        public Task<int> CreateTripRole(TripRole triprole);
        //UPDATE
        public Task<int> UpdateTripRole(TripRole triprole);
        //DELETE
        public Task<int> DeleteTripRole(int roleId);
    }
}
