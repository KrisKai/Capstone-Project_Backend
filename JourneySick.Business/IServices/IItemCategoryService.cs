using JourneySick.Business.Models.DTOs;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;

namespace JourneySick.Business.IServices
{
    public interface IItemService
    {
        //Select list w paging
        public Task<AllItemDTO> GetAllItemsWithPaging(int pageIndex, int pageSize, string? itemId);
        //Select Item
        public Task<ItemDTO> GetItemById(int itemId);
        //insert
        public Task<int> CreateItem(ItemDTO tripItemDTO, CurrentUserObj currentUser);
        //update
        public Task<int> UpdateItem(ItemDTO tripItemDTO, CurrentUserObj currentUser);
        //update
        public Task<int> DeleteItem(int itemId);

    }
}
