using AutoMapper;
using JourneySick.Data.IRepositories;
using JourneySick.Data.IRepositories.Repositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.VO;

namespace JourneySick.Business.IServices.Services
{
    public class TripRoleService : ITripRoleService
    {
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;

        public TripRoleService(ITripRepository tripRepository, IMapper mapper)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
        }

        public Task<string> CreateTripRole(TripRoleDTO planLocationDTO)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteTripRole(string locationId)
        {
            throw new NotImplementedException();
        }

        public Task<List<TripRoleDTO>> GetAllTripRolesWithPaging(int pageIndex, int pageSize, UserDetailDTO currentUser)
        {
            throw new NotImplementedException();
        }

        public Task<TripRoleDTO> GetTripRole(string roleId)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateTripRole(TripRoleDTO planLocationDTO)
        {
            throw new NotImplementedException();
        }
    }
}
