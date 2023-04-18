using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.IRepositories
{
    public interface ITripPlanRepository
    {
        //SELECT ALL
        public Task<List<Tbltripplan>> GetAllTripPlansWithPaging(int pageIndex, int pageSize, string? planId);
        //CREATE
        public Task<int> CreateTripPlan(Tbltripplan tbltripplan);
        public Task<Tbltripplan> GetTripPlanById(int tripPlanId);
        public Task<int> UpdateTripPlan(Tbltripplan tbltripplan);
        public Task<int> DeleteTripPlan(int tripPlanId);
        public Task<int> CountAllTripPlans(string? tripName);
    }
}
