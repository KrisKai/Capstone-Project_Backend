using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.VO;
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
        public Task<List<Tblplanlocation>> SelectAllLocationsWithPaging(int pageIndex, int pageSize);
        //CREATE
        public Task<int> CreatePlanLocation(Tblplanlocation tblplanlocation);
        public Task<int> GetLastOneId();
        public Task<Tblplanlocation> GetPlanLocationById(int locationId);
        public Task<int> UpdatePlanLocation(Tblplanlocation tblplanlocation);
        public Task<int> DeletePlanLocation(int locationId);

    }
}
