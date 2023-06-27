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
        public Task<TripItem> GetTripItemById(int tripItemId);
        //SELECT ALL
        public Task<List<TripItem>> GetAllTripItemsWithPaging(int pageIndex, int pageSize, string? itemId, int categoryId, string tripId);
        public Task<int> CountAllTripItems(string? tripName, int categoryId, string tripId);
        public Task<int> CheckIfItemNameExisted(string tripId, string itemName);
        //CREATE
        public Task<int> CreateTripItem(TripItem tripitem);
        public Task<int> UpdateTripItem(TripItem tripitem);
        public Task<int> DeleteTripItem(int tripItemId);
        public Task<int> DeleteTripItemByTripId(string tripId);
    }
}
