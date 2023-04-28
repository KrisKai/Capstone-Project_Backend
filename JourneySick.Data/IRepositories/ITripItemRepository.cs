using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.IRepositories
{
    public interface ITripItemRepository
    {
        //SELECT ALL
        public Task<List<Tbltripitem>> GetAllTripItemsWithPaging(int pageIndex, int pageSize, string? itemId, int categoryId);
        //CREATE
        public Task<int> CreateTripItem(Tbltripitem tbltripitem);
        public Task<Tbltripitem> GetTripItemById(int tripItemId);
        public Task<int> UpdateTripItem(Tbltripitem tbltripitem);
        public Task<int> DeleteTripItem(int tripItemId);
        public Task<int> CountAllTripItems(string? tripName, int categoryId);
    }
}
