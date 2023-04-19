using JourneySick.Business.Models.DTOs;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;

namespace JourneySick.Business.IServices
{
    public interface IItemCategoryService
    {
        //Select list w paging
        public Task<AllItemCategoryDTO> GetAllItemCategorysWithPaging(int pageIndex, int pageSize, string? itemId);
        //Select ItemCategory
        public Task<ItemCategoryDTO> GetItemCategoryById(int itemId);
        //insert
        public Task<int> CreateItemCategory(ItemCategoryDTO tripItemCategoryDTO, CurrentUserObj currentUser);
        //update
        public Task<int> UpdateItemCategory(ItemCategoryDTO tripItemCategoryDTO, CurrentUserObj currentUser);
        //update
        public Task<int> DeleteItemCategory(int itemId);

    }
}
