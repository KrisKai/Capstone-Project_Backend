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
                List<Tblitemcategory> ItemDTO = await _itemCategoryRepository.GetAllItemCategorysWithPaging(pageIndex, pageSize, itemCategoryId);
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
                Tblitemcategory tblitemCategory = await _itemCategoryRepository.GetItemCategoryById(itemCategoryId);
                // convert entity to dto
                ItemCategoryDTO itemCategoryDTO = _mapper.Map<ItemCategoryDTO>(tblitemCategory);

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
                itemCategoryDTO.FldCreateBy = currentUser.UserId;
                itemCategoryDTO.FldCreateDate = DateTime.Now;
                Tblitemcategory tblitemCategory = _mapper.Map<Tblitemcategory>(itemCategoryDTO);
                int id = await _itemCategoryRepository.CreateItemCategory(tblitemCategory);
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
                ItemCategoryDTO getTrip = await GetItemCategoryById((int)itemCategoryDTO.FldCategoryId);

                if (getTrip != null)
                {
                    itemCategoryDTO.FldUpdateBy = currentUser.UserId;
                    itemCategoryDTO.FldUpdateDate = DateTime.Now;
                    Tblitemcategory tblitemCategory = _mapper.Map<Tblitemcategory>(itemCategoryDTO);
                    if (await _itemCategoryRepository.UpdateItemCategory(tblitemCategory) > 0)
                    {
                        return (int)itemCategoryDTO.FldCategoryId;
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
