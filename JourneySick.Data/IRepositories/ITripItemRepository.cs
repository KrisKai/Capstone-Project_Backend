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
        public Task<List<TripItem>> GetAllTripItemsWithPaging(int pageIndex, int pageSize, string? itemId, int categoryId);
        //CREATE
        public Task<int> CreateTripItem(TripItem tripitem);
        public Task<TripItem> GetTripItemById(int tripItemId);
        public Task<int> UpdateTripItem(TripItem tripitem);
        public Task<int> DeleteTripItem(int tripItemId);
        public Task<int> CountAllTripItems(string? tripName, int categoryId);
    }
}
