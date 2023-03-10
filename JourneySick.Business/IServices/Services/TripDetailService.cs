using AutoMapper;
using JourneySick.Data.IRepositories;
using JourneySick.Data.IRepositories.Repositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.VO;

namespace JourneySick.Business.IServices.Services
{
    public class TripDetailService : ITripDetailService
    {
        private readonly ITripDetailRepository _tripDetailRepository;
        private readonly IMapper _mapper;
        public TripDetailService(ITripDetailRepository tripDetailRepository, IMapper mapper)
        {
            _tripDetailRepository = tripDetailRepository;
            _mapper = mapper;
        }
        public Task<string> CreateTripDetail(TripDetailDTO tripDetailDTO)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteTripDetail(int locationId)
        {
            throw new NotImplementedException();
        }

        public Task<List<TripDetailDTO>> GetAllTripDetailsWithPaging(int pageIndex, int pageSize, UserDetailDTO currentUser)
        {
            throw new NotImplementedException();
        }

        public Task<TripDetailDTO> GetTripDetailById(int locationId)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateTripDetail(TripDetailDTO tripDetailDTO)
        {
            throw new NotImplementedException();
        }
    }
}
