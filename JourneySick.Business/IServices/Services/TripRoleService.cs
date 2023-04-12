using AutoMapper;
using JourneySick.Business.Models.DTOs;
using JourneySick.Data.IRepositories;
using JourneySick.Data.IRepositories.Repositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;

namespace JourneySick.Business.IServices.Services
{
    public class TripRoleService : ITripRoleService
    {
        private readonly ITripRoleRepository _tripRoleRepository;
        private readonly IMapper _mapper;

        public TripRoleService(ITripRoleRepository tripRoleRepository, IMapper mapper)
        {
            _tripRoleRepository = tripRoleRepository;
            _mapper = mapper;
        }


        public async Task<AllTripRoleDTO> GetAllTripRolesWithPaging(int pageIndex, int pageSize, string? roleName)
        {
            AllTripRoleDTO result = new();
            try
            {
                List<Tbltriprole> tbltriproles = await _tripRoleRepository.GetAllTripRolesWithPaging(pageIndex, pageSize, roleName);
                // convert entity to dto
                List<TripRoleDTO> users = _mapper.Map<List<TripRoleDTO>>(tbltriproles);
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

        public async Task<TripRoleDTO> GetTripRole(string roleId)
        {
            throw new NotImplementedException();
        }

        public async Task<string> CreateTripRole(TripRoleDTO planLocationDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UpdateTripRole(TripRoleDTO planLocationDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<string> DeleteTripRole(string locationId)
        {
            throw new NotImplementedException();
        }
    }
}
