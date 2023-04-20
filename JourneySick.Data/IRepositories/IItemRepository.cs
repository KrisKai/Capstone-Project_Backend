using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
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
        public Task<List<Tblitem>> GetAllItemsWithPaging(int pageIndex, int pageSize, string? itemId);
        public Task<Tblitem> GetItemById(int itemId);
        public Task<Tblitem> GetItemByName(string itemName);
        //CREATE
        public Task<int> CreateItem(Tblitem tblitem);
        public Task<int> UpdateItem(Tblitem tblitem);
        public Task<int> DeleteItem(int itemId);
        public Task<int> CountAllItems(string? tripName);
    }
}
