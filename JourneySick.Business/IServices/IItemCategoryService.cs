using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.Request;

namespace JourneySick.Business.IServices
{
    public interface IItemCategoryService
    {
        //Select list w paging
        public Task<AllItemCategoryDTO> GetAllItemCategorysWithPaging(int pageIndex, int pageSize, string? itemId);
        //Select ItemCategory
        public Task<ItemCategoryDTO> GetItemCategoryById(int itemId);
        //insert
        public Task<int> CreateItemCategory(ItemCategoryDTO tripItemCategoryDTO, CurrentUserRequest currentUser);
        //update
        public Task<int> UpdateItemCategory(ItemCategoryDTO tripItemCategoryDTO, CurrentUserRequest currentUser);
        //update
        public Task<int> DeleteItemCategory(int itemId);

    }
}
