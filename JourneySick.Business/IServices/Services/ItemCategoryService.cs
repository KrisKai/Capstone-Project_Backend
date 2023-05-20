using AutoMapper;
using JourneySick.Business.Helpers;
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
    public class ItemCategoryService : IItemCategoryService
    {
        private readonly IItemCategoryRepository _itemCategoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ItemCategoryService> _logger;
        public ItemCategoryService(IItemCategoryRepository itemCategoryRepository, IMapper mapper, ILogger<ItemCategoryService> logger)
        {
            _itemCategoryRepository = itemCategoryRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<AllItemCategoryDTO> GetAllItemCategorysWithPaging(int pageIndex, int pageSize, string? itemCategoryId)
        {
            AllItemCategoryDTO result = new();
            try
            {
                List<itemcategory> ItemDTO = await _itemCategoryRepository.GetAllItemCategorysWithPaging(pageIndex, pageSize, itemCategoryId);
                // convert entity to dto
                List<ItemCategoryDTO> itemCategoryDTOs = _mapper.Map<List<ItemCategoryDTO>>(ItemDTO);
                int count = await _itemCategoryRepository.CountAllItemCategorys(itemCategoryId);
                result.ListOfCategory = itemCategoryDTOs;
                result.NumOfCategory = count;
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<ItemCategoryDTO> GetItemCategoryById(int itemCategoryId)
        {
            try
            {
                itemcategory itemCategory = await _itemCategoryRepository.GetItemCategoryById(itemCategoryId);
                // convert entity to dto
                ItemCategoryDTO itemCategoryDTO = _mapper.Map<ItemCategoryDTO>(itemCategory);

                return itemCategoryDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<int> CreateItemCategory(ItemCategoryDTO itemCategoryDTO, CurrentUserObj currentUser)
        {
            try
            {
                itemCategoryDTO.CreateBy = currentUser.UserId;
                itemCategoryDTO.CreateDate = DateTimePicker.GetDateTimeByTimeZone();
                itemcategory itemCategory = _mapper.Map<itemcategory>(itemCategoryDTO);
                int id = await _itemCategoryRepository.CreateItemCategory(itemCategory);
                if (id > 0)
                {
                    return id;
                }
                throw new InsertException("Create Item Category failed!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<int> UpdateItemCategory(ItemCategoryDTO itemCategoryDTO, CurrentUserObj currentUser)
        {
            try
            {
                ItemCategoryDTO getTrip = await GetItemCategoryById((int)itemCategoryDTO.CategoryId);

                if (getTrip != null)
                {
                    itemCategoryDTO.UpdateBy = currentUser.UserId;
                    itemCategoryDTO.UpdateDate = DateTimePicker.GetDateTimeByTimeZone();
                    itemcategory itemCategory = _mapper.Map<itemcategory>(itemCategoryDTO);
                    if (await _itemCategoryRepository.UpdateItemCategory(itemCategory) > 0)
                    {
                        return (int)itemCategoryDTO.CategoryId;
                    }
                    else
                    {
                        throw new UpdateException("Update Item Category failed!");
                    }
                }
                else
                {
                    throw new GetOneException("Item Category is not existed!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<int> DeleteItemCategory(int itemCategoryId)
        {
            try
            {
                ItemCategoryDTO getTrip = await GetItemCategoryById(itemCategoryId);

                if (getTrip != null)
                {
                    if (await _itemCategoryRepository.DeleteItemCategory(itemCategoryId) > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        throw new DeleteException("Delete Item Category failed!");
                    }

                }
                else
                {
                    throw new GetOneException("Item Category is not existed!");
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
