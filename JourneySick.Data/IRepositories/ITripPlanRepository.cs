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
    public interface ITripPlanRepository
    {
        //CREATE
        public Task<int> CreateTripPlan(Tbltripplan tbltripplan);
        public Task<string> GetLastOneId();
        Task<Tbltripplan> SelectTripPlan(string tripPlanId);
        Task<int> UpdateTripPlan(Tbltripplan tbltripplan);
    }
}
