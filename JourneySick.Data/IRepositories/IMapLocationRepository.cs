using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.IRepositories
{
    public interface IMapLocationRepository
    {
        //SELECT ALL
        public Task<List<MapLocation>> GetAllLocationsWithPaging(int pageIndex, int pageSize);
        public Task<MapLocation> GetMapLocationById(int locationId);
        //CREATE
        public Task<long> CreateMapLocation(MapLocation maplocation);
        //UPDATE
        public Task<int> UpdateMapLocation(MapLocation maplocation);
        //DELETE
        public Task<int> DeleteMapLocation(int locationId);

    }
}
