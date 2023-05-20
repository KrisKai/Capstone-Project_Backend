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
using System.Numerics;

namespace JourneySick.Business.IServices.Services
{
    public class TripRoleService : ITripRoleService
    {
        private readonly ITripRoleRepository _tripRoleRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<TripRoleService> _logger;

        public TripRoleService(ITripRoleRepository tripRoleRepository, IMapper mapper, ILogger<TripRoleService> logger)
        {
            _tripRoleRepository = tripRoleRepository;
            _mapper = mapper;
            _logger = logger;
        }


        public async Task<AllTripRoleDTO> GetAllTripRolesWithPaging(int pageIndex, int pageSize, string? roleName)
        {
            AllTripRoleDTO result = new();
            try
            {
                List<triprole> triproles = await _tripRoleRepository.GetAllTripRolesWithPaging(pageIndex, pageSize, roleName);
                // convert entity to dto
                List<TripRoleDTO> users = _mapper.Map<List<TripRoleDTO>>(triproles);
                int count = await _tripRoleRepository.CountAllTripRoles(roleName);
                result.ListOfRole = users;
                result.NumOfRole = count;
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<TripRoleDTO> GetTripRoleById(int roleId)
        {
            try
            {
                TripRole triprole = await _tripRoleRepository.GetTripRoleById(roleId);
                // convert entity to dto
                TripRoleDTO tripRoleDTO = _mapper.Map<TripRoleDTO>(triprole);

                return tripRoleDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<int> CreateTripRole(TripRoleDTO tripRoleDTO)
        {
            try
            {
                TripRole triprole = _mapper.Map<TripRole>(tripRoleDTO);
                int id = await _tripRoleRepository.CreateTripRole(triprole);
                if (id > 0)
                {
                    return id;
                }
                throw new InsertException("Create trip plan failed!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<int> UpdateTripRole(TripRoleDTO tripRoleDTO)
        {
            try
            {
                TripRoleDTO getTrip = await GetTripRoleById((int)tripRoleDTO.RoleId);

                if (getTrip != null)
                {
                    TripRole triprole = _mapper.Map<TripRole>(tripRoleDTO);
                    if (await _tripRoleRepository.UpdateTripRole(triprole) > 0)
                    {
                        return (int)tripRoleDTO.RoleId;
                    }
                    else
                    {
                        throw new UpdateException("Update trip role failed!");
                    }
                }
                else
                {
                    throw new GetOneException("Trip role is not existed!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<int> DeleteTripRole(int roleId)
        {
            try
            {
                TripRoleDTO getTrip = await GetTripRoleById(roleId);

                if (getTrip != null)
                {
                    if (await _tripRoleRepository.DeleteTripRole(roleId) > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        throw new DeleteException("Delete trip role failed!");
                    }

                }
                else
                {
                    throw new GetOneException("Trip role is not existed!");
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
