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
    public class TripMemberService : ITripMemberService
    {
        private readonly ITripMemberRepository _tripMemberRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<TripMemberService> _logger;

        public TripMemberService(ITripMemberRepository tripMemberRepository, IMapper mapper, ILogger<TripMemberService> logger)
        {
            _tripMemberRepository = tripMemberRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<AllTripMemberDTO> GetAllTripMembersWithPaging(int pageIndex, int pageSize, string? memberName)
        {
            AllTripMemberDTO result = new();
            try
            {
                List<TbltripmemberVO> tbltripmembers = await _tripMemberRepository.GetAllTripMembersWithPaging(pageIndex, pageSize, memberName);
                // convert entity to dto
                List<TripMemberVO> tripMemberDTOs = _mapper.Map<List<TripMemberVO>>(tbltripmembers);
                int count = await _tripMemberRepository.CountAllTripMembers(memberName);
                result.ListOfMember = tripMemberDTOs;
                result.NumOfMember = count;
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<TripMemberDTO> GetTripMemberById(int memberId)
        {
            try
            {
                Tbltripmember tbltripmember = await _tripMemberRepository.GetTripMemberById(memberId);
                // convert entity to dto
                TripMemberDTO tripMemberDTO = _mapper.Map<TripMemberDTO>(tbltripmember);

                return tripMemberDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<int> CreateTripMember(TripMemberDTO tripMemberDTO)
        {
            try
            {
                //int lastOne = await _tripMemberRepository.GetLastOneId();
                //tripMemberDTO.FldPlanId = lastOne + 1;
                tripMemberDTO.FldCreateBy = "Admin";
                tripMemberDTO.FldCreateDate = DateTime.Now;
                Tbltripmember tbltripmember = _mapper.Map<Tbltripmember>(tripMemberDTO);
                int id = await _tripMemberRepository.CreateTripMember(tbltripmember);
                if (id > 0)
                {
                    return id;
                }
                throw new InsertException("Create trip member failed!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<int> UpdateTripMember(TripMemberDTO tripMemberDTO)
        {
            try
            {
                TripMemberDTO getTrip = await GetTripMemberById((int)tripMemberDTO.FldMemberId);

                if (getTrip != null)
                {
                    tripMemberDTO.FldUpdateBy = "Admin";
                    tripMemberDTO.FldUpdateDate = DateTime.Now;
                    Tbltripmember tbltripmember = _mapper.Map<Tbltripmember>(tripMemberDTO);
                    if (await _tripMemberRepository.UpdateTripMember(tbltripmember) > 0)
                    {
                        return (int)tripMemberDTO.FldMemberId;
                    }
                    else
                    {
                        throw new UpdateException("Update trip member failed!");
                    }
                }
                else
                {
                    throw new GetOneException("Trip member is not existed!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<int> DeleteTripMember(int memberId)
        {
            try
            {
                TripMemberDTO getTrip = await GetTripMemberById(memberId);

                if (getTrip != null)
                {
                    if (await _tripMemberRepository.DeleteTripMember(memberId) > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        throw new DeleteException("Delete trip member failed!");
                    }

                }
                else
                {
                    throw new GetOneException("Trip member is not existed!");
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
