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
        public Task<List<TripPlan>> GetAllTripPlansWithPaging(int pageIndex, int pageSize, string? planId);
        //CREATE
        public Task<int> CreateTripPlan(TripPlan tripplan);
        public Task<TripPlan> GetTripPlanById(int tripPlanId);
        public Task<int> UpdateTripPlan(TripPlan tripplan);
        public Task<int> DeleteTripPlan(int tripPlanId);
        public Task<int> CountAllTripPlans(string? tripName);
    }
}
