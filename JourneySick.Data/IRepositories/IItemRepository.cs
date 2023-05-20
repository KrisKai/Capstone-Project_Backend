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
    public interface IItemRepository
    {
        //SELECT ALL
        public Task<List<ItemVO>> GetAllItemsWithPaging(int pageIndex, int pageSize, string? itemId, int categoryId);
        public Task<Item> GetItemById(int itemId);
        public Task<Item> GetItemByName(string itemName);
        //CREATE
        public Task<int> CreateItem(Item item);
        public Task<int> UpdateItem(Item item);
        public Task<int> DeleteItem(int itemId);
        public Task<int> CountAllItems(string? tripName, int categoryId);
    }
}
