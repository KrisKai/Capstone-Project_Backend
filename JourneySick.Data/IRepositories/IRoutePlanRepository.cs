using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.IRepositories
{
    public interface IRoutePlanRepository
    {
        //SELECT ALL
        public Task<List<Tblrouteplan>> GetAllRoutePlansWithPaging(int pageIndex, int pageSize, string? routeId);
        public Task<int> CountAllRoutePlans(string? tripName);
        public Task<Tblrouteplan> GetRoutePlanById(int routePlanId);
        //CREATE
        public Task<int> CreateRoutePlan(Tblrouteplan tblrouteplan);
        public Task<int> UpdateRoutePlan(Tblrouteplan tblrouteplan);
        public Task<int> DeleteRoutePlan(int routePlanId);
    }
}
