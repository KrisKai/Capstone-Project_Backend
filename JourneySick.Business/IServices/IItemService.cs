using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.Request;

namespace JourneySick.Business.IServices
{
    public interface IItemService
    {
        //Select list w paging
        public Task<AllItemDTO> GetAllItemsWithPaging(int pageIndex, int pageSize, string? itemId, int categoryId);
        //Select Item
        public Task<ItemDTO> GetItemById(int itemId);
        //insert
        public Task<int> CreateItem(ItemDTO tripItemDTO, CurrentUserObject currentUser);
        //update
        public Task<int> UpdateItem(ItemDTO tripItemDTO, CurrentUserObject currentUser);
        //update
        public Task<int> DeleteItem(int itemId);

    }
}
