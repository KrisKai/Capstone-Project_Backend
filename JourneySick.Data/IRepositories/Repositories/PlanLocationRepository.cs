﻿using Dapper;
using JourneySick.Data.Helpers;
using JourneySick.Data.Models.Entities;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace JourneySick.Data.IRepositories.Repositories
{
    public class PlanLocationRepository : BaseRepository, IPlanLocationRepository
    {
        public PlanLocationRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public Task<int> CreatePlanLocation(Tblplanlocation tblplanlocation)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeletePlanLocation(int locationId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetLastOneId()
        {
            throw new NotImplementedException();
        }

        public Task<Tblplanlocation> GetPlanLocationById(int locationId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Tblplanlocation>> GetAllLocationsWithPaging(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdatePlanLocation(Tblplanlocation tblplanlocation)
        {
            throw new NotImplementedException();
        }
    }
}
