using AutoMapper;
using JourneySick.Business.Helpers;
using JourneySick.Business.Helpers.Exceptions;
using JourneySick.Data.IRepositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.Request;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;
using Microsoft.Extensions.Logging;

namespace JourneySick.Business.IServices.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ItemService> _logger;
        public ItemService(IItemRepository itemRepository, IMapper mapper, ILogger<ItemService> logger)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<AllItemDTO> GetAllItemsWithPaging(int pageIndex, int pageSize, string? itemId, int categoryId)
        {
            AllItemDTO result = new();
            try
            {
                List<ItemVO> items = await _itemRepository.GetAllItemsWithPaging(pageIndex, pageSize, itemId, categoryId);
/*                // convert entity to dto
                List<ItemRequest> itemRequests = _mapper.Map<List<ItemRequest>>(items);*/
                int count = await _itemRepository.CountAllItems(itemId, categoryId);
                result.ListOfItem = items;
                result.NumOfItem = count;
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<ItemDTO> GetItemById(int itemId)
        {
            try
            {
                Item item = await _itemRepository.GetItemById(itemId);
                // convert entity to dto
                ItemDTO itemDTO = _mapper.Map<ItemDTO>(item);

                return itemDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<int> CreateItem(CreateItemRequest itemRequest, CurrentUserObject currentUser)
        {
            try
            {
                itemRequest.CreateBy = currentUser.UserId;
                itemRequest.CreateDate = DateTimePicker.GetDateTimeByTimeZone();
                Item item = _mapper.Map<Item>(itemRequest);
                int check = await _itemRepository.CreateItem(item);
                if (check > 0)
                {
                    return check;
                }
                throw new InsertException("Create trip item failed!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<int> UpdateItem(UpdateItemRequest itemRequest, CurrentUserObject currentUser)
        {
            try
            {
                ItemDTO getTrip = await GetItemById((int)itemRequest.ItemId);

                if (getTrip != null)
                {
                    itemRequest.UpdateBy = currentUser.UserId;
                    itemRequest.UpdateDate = DateTimePicker.GetDateTimeByTimeZone();
                    Item item = _mapper.Map<Item>(itemRequest);
                    if (await _itemRepository.UpdateItem(item) > 0)
                    {
                        return (int)itemRequest.ItemId;
                    }
                    else
                    {
                        throw new UpdateException("Update trip item failed!");
                    }
                }
                else
                {
                    throw new GetOneException("Trip item is not existed!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<int> DeleteItem(int itemId)
        {
            try
            {
                ItemDTO getTrip = await GetItemById(itemId);

                if (getTrip != null)
                {
                    if (await _itemRepository.DeleteItem(itemId) > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        throw new DeleteException("Delete trip item failed!");
                    }

                }
                else
                {
                    throw new GetOneException("Trip item is not existed!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

    }
}
