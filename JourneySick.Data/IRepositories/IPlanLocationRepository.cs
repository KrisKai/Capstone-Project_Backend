using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.IRepositories
{
    public interface IPlanLocationRepository
    {
        //SELECT ALL
        public Task<List<PlanLocation>> GetAllLocationsWithPaging(int pageIndex, int pageSize);
        //CREATE
        public Task<int> CreatePlanLocation(PlanLocation planlocation);
        public Task<PlanLocation> GetPlanLocationById(int locationId);
        //UPDATE
        public Task<int> UpdatePlanLocation(PlanLocation planlocation);
        //DELETE
        public Task<int> DeletePlanLocation(int locationId);

    }
}
