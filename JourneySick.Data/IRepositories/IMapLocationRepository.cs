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
        public Task<List<Tblmaplocation>> GetAllLocationsWithPaging(int pageIndex, int pageSize);
        //CREATE
        public Task<int> CreateMapLocation(Tblmaplocation tblmaplocation);
        public Task<Tblmaplocation> GetMapLocationById(int locationId);
        //UPDATE
        public Task<int> UpdateMapLocation(Tblmaplocation tblmaplocation);
        //DELETE
        public Task<int> DeleteMapLocation(int locationId);

    }
}
