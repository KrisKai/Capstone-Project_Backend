using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.IRepositories
{
    public interface IItemCategoryRepository
    {
        //SELECT ALL
        public Task<List<ItemCategory>> GetAllItemCategorysWithPaging(int pageIndex, int pageSize, string? itemCategoryId);
        //CREATE
        public Task<int> CreateItemCategory(ItemCategory itemCategory);
        public Task<ItemCategory> GetItemCategoryById(int itemCategoryId);
        public Task<int> UpdateItemCategory(ItemCategory itemCategory);
        public Task<int> DeleteItemCategory(int itemCategoryId);
        public Task<int> CountAllItemCategorys(string? tripName);
    }
}
