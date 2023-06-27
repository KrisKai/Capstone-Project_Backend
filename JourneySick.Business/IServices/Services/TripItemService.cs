using AutoMapper;
using JourneySick.Business.Helpers;
using JourneySick.Business.Helpers.Exceptions;
using JourneySick.Data.IRepositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.Request;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;
using Microsoft.Extensions.Logging;

namespace JourneySick.Business.IServices.Services
{
    public class TripItemService : ITripItemService
    {
        private readonly ITripItemRepository _tripItemRepository;
        private readonly IItemRepository _itemRepository;
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<TripItemService> _logger;
        public TripItemService(ITripRepository tripRepository, ITripItemRepository tripItemRepository, IItemRepository itemRepository, IMapper mapper, ILogger<TripItemService> logger)
        {
            _tripRepository = tripRepository;
            _tripItemRepository = tripItemRepository;
            _itemRepository = itemRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<AllTripItemDTO> GetAllTripItemsWithPaging(int pageIndex, int pageSize, string? itemId, int categoryId, string tripId)
        {
            AllTripItemDTO result = new();
            try
            {
                List<TripItem> tripItems = await _tripItemRepository.GetAllTripItemsWithPaging(pageIndex, pageSize, itemId, categoryId, tripId);
                // convert entity to dto
                List<TripItemDTO> tripItemsDTO = _mapper.Map<List<TripItemDTO>>(tripItems);
                int count = await _tripItemRepository.CountAllTripItems(itemId, categoryId, tripId);
                result.ListOfItem = tripItemsDTO;
                result.NumOfItem = count;
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<TripItemDTO> GetTripItemById(int itemId)
        {
            try
            {
                TripItem tripitem = await _tripItemRepository.GetTripItemById(itemId);
                // convert entity to dto
                TripItemDTO tripItemDTO = _mapper.Map<TripItemDTO>(tripitem);

                return tripItemDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<int> CreateTripItem(TripItemDTO tripItemDTO, CurrentUserObject currentUser)
        {
            try
            {
                int count = await _tripItemRepository.CheckIfItemNameExisted(tripItemDTO.TripId, tripItemDTO.ItemName);
                if (count > 0)
                {
                    throw new InsertException("Vật dụng này đã tồn tại!");
                }
                tripItemDTO.CreateBy = currentUser.UserId;
                tripItemDTO.CreateDate = DateTimePicker.GetDateTimeByTimeZone();
                TripItem tripitem = _mapper.Map<TripItem>(tripItemDTO);
                int id = await _tripItemRepository.CreateTripItem(tripitem);
                if (id > 0)
                {
                    Item item = await _itemRepository.GetItemByName(tripitem.ItemName);
                    if (item != null)
                    {
                        item.Quantity++;
                        await _itemRepository.UpdateItem(item);
                    }
                    else
                    {
                        Item newitem = new()
                        {
                            Quantity = 1,
                            ItemName = tripitem.ItemName,
                            CategoryId = (int)tripitem.CategoryId,
                            CreateBy = tripitem.CreateBy,
                            CreateDate = tripitem.CreateDate
                        };
                        await _itemRepository.CreateItem(newitem);
                    }
                    TripVO trip = await _tripRepository.GetTripById(tripItemDTO.TripId);
                    trip.TripId = tripitem.TripId;
                    trip.TripBudget += (tripitem.Quantity * tripitem.PriceMin);
                    await _tripRepository.UpdateTripBudget(trip);
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

        public async Task<int> UpdateTripItem(TripItemDTO tripItemDTO, CurrentUserObject currentUser)
        {
            try
            {
                TripItemDTO getTrip = await GetTripItemById((int)tripItemDTO.ItemId);

                if (getTrip != null)
                {
                    int count = await _tripItemRepository.CheckIfItemNameExisted(tripItemDTO.TripId, tripItemDTO.ItemName);
                    if (count > 0 && !tripItemDTO.ItemName.Equals(getTrip.ItemName))
                    {
                        throw new InsertException("Vật dụng này đã tồn tại!");
                    }
                    tripItemDTO.UpdateBy = currentUser.UserId;
                    tripItemDTO.UpdateDate = DateTimePicker.GetDateTimeByTimeZone();
                    TripItem tripitem = _mapper.Map<TripItem>(tripItemDTO);
                    if (await _tripItemRepository.UpdateTripItem(tripitem) > 0)
                    {
                        if (getTrip.PriceMin != tripItemDTO.PriceMin || getTrip.Quantity != tripItemDTO.Quantity)
                        {
                            TripVO tripVO = await _tripRepository.GetTripById(tripItemDTO.TripId);
                            tripVO.TripBudget = tripVO.TripBudget - (getTrip.Quantity * getTrip.PriceMin) + (tripItemDTO.Quantity * tripItemDTO.PriceMin);
                            await _tripRepository.UpdateTripBudget(tripVO);
                        }
                        return (int)tripItemDTO.ItemId;
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

        public async Task<int> DeleteTripItem(int itemId)
        {
            try
            {
                TripItemDTO getTrip = await GetTripItemById(itemId);

                if (getTrip != null)
                {
                    if (await _tripItemRepository.DeleteTripItem(itemId) > 0)
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
