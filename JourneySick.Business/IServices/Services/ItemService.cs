using AutoMapper;
using JourneySick.Business.Helpers.Exceptions;
using JourneySick.Business.Models.DTOs;
using JourneySick.Data.IRepositories;
using JourneySick.Data.IRepositories.Repositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
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
        public async Task<AllItemDTO> GetAllItemsWithPaging(int pageIndex, int pageSize, string? itemId)
        {
            AllItemDTO result = new();
            try
            {
                List<Tblitem> tbltrips = await _itemRepository.GetAllItemsWithPaging(pageIndex, pageSize, itemId);
                // convert entity to dto
                List<ItemDTO> trips = _mapper.Map<List<ItemDTO>>(tbltrips);
                int count = await _itemRepository.CountAllItems(itemId);
                result.ListOfItem = trips;
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
                Tblitem tblitem = await _itemRepository.GetItemById(itemId);
                // convert entity to dto
                ItemDTO itemDTO = _mapper.Map<ItemDTO>(tblitem);

                return itemDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<int> CreateItem(ItemDTO itemDTO, CurrentUserObj currentUser)
        {
            try
            {
                itemDTO.FldCreateBy = currentUser.UserId;
                itemDTO.FldCreateDate = DateTime.Now;
                Tblitem tblitem = _mapper.Map<Tblitem>(itemDTO);
                int id = await _itemRepository.CreateItem(tblitem);
                if (id > 0)
                {
                    return id;
                }
                throw new InsertException("Create trip item failed!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<int> UpdateItem(ItemDTO itemDTO, CurrentUserObj currentUser)
        {
            try
            {
                ItemDTO getTrip = await GetItemById((int)itemDTO.FldItemId);

                if (getTrip != null)
                {
                    itemDTO.FldUpdateBy = currentUser.UserId;
                    itemDTO.FldUpdateDate = DateTime.Now;
                    Tblitem tblitem = _mapper.Map<Tblitem>(itemDTO);
                    if (await _itemRepository.UpdateItem(tblitem) > 0)
                    {
                        return (int)itemDTO.FldItemId;
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
