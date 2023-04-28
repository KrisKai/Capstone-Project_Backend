using JourneySick.Business.Models.DTOs;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;

namespace JourneySick.Business.IServices
{
    public interface ITripItemService
    {
        //Select list w paging
        public Task<AllTripItemDTO> GetAllTripItemsWithPaging(int pageIndex, int pageSize, string? itemId, int categoryId);
        //Select Item
        public Task<TripItemDTO> GetTripItemById(int itemId);
        //insert
        public Task<int> CreateTripItem(TripItemDTO tripItemDTO, CurrentUserObj currentUser);
        //update
        public Task<int> UpdateTripItem(TripItemDTO tripItemDTO, CurrentUserObj currentUser);
        //update
        public Task<int> DeleteTripItem(int itemId);

    }
}
