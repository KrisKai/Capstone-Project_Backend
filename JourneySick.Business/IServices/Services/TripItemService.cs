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
    public class TripItemService : ITripItemService
    {
        private readonly ITripItemRepository _tripItemRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<TripItemService> _logger;
        public TripItemService(ITripItemRepository tripItemRepository, IMapper mapper, ILogger<TripItemService> logger)
        {
            _tripItemRepository = tripItemRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<AllTripItemDTO> GetAllTripItemsWithPaging(int pageIndex, int pageSize, string? itemId)
        {
            AllTripItemDTO result = new();
            try
            {
                List<Tbltripitem> tbltrips = await _tripItemRepository.GetAllTripItemsWithPaging(pageIndex, pageSize, itemId);
                // convert entity to dto
                List<TripItemDTO> trips = _mapper.Map<List<TripItemDTO>>(tbltrips);
                int count = await _tripItemRepository.CountAllTripItems(itemId);
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

        public async Task<TripItemDTO> GetTripItemById(int itemId)
        {
            try
            {
                Tbltripitem tbltripitem = await _tripItemRepository.GetTripItemById(itemId);
                // convert entity to dto
                TripItemDTO tripItemDTO = _mapper.Map<TripItemDTO>(tbltripitem);

                return tripItemDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<int> CreateTripItem(TripItemDTO tripItemDTO, CurrentUserObj currentUser)
        {
            try
            {
                tripItemDTO.FldCreateBy = currentUser.UserId;
                tripItemDTO.FldCreateDate = DateTime.Now;
                Tbltripitem tbltripitem = _mapper.Map<Tbltripitem>(tripItemDTO);
                int id = await _tripItemRepository.CreateTripItem(tbltripitem);
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

        public async Task<int> UpdateTripItem(TripItemDTO tripItemDTO, CurrentUserObj currentUser)
        {
            try
            {
                TripItemDTO getTrip = await GetTripItemById((int)tripItemDTO.FldItemId);

                if (getTrip != null)
                {
                    tripItemDTO.FldUpdateBy = currentUser.UserId;
                    tripItemDTO.FldUpdateDate = DateTime.Now;
                    Tbltripitem tbltripitem = _mapper.Map<Tbltripitem>(tripItemDTO);
                    if (await _tripItemRepository.UpdateTripItem(tbltripitem) > 0)
                    {
                        return (int)tripItemDTO.FldItemId;
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
