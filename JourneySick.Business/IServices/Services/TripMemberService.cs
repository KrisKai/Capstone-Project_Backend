using AutoMapper;
using AutoMapper.Execution;
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
using RevenueSharingInvest.Business.Services.Extensions.Email;
using System.Numerics;

namespace JourneySick.Business.IServices.Services
{
    public class TripMemberService : ITripMemberService
    {
        private readonly ITripMemberRepository _tripMemberRepository;
        private readonly IUserDetailRepository _userDetailRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<TripMemberService> _logger;

        public TripMemberService(ITripMemberRepository tripMemberRepository, IUserDetailRepository userDetailRepository, IMapper mapper, ILogger<TripMemberService> logger)
        {
            _tripMemberRepository = tripMemberRepository;
            _userDetailRepository = userDetailRepository;
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

        public async Task<TripMemberVO> GetTripMemberById(int memberId)
        {
            try
            {
                TbltripmemberVO tbltripmember = await _tripMemberRepository.GetTripMemberById(memberId);
                // convert entity to dto
                TripMemberVO tripMemberDTO = _mapper.Map<TripMemberVO>(tbltripmember);

                return tripMemberDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<int> CreateTripMember(TripMemberDTO tripMemberDTO, CurrentUserObj currentUser)
        {
            try
            {
                if (await _tripMemberRepository.CountTripMemberByUserIdAndTripId(tripMemberDTO.FldUserId, tripMemberDTO.FldTripId) == 0)
                {
                    tripMemberDTO.FldCreateBy = currentUser.UserId;
                    tripMemberDTO.FldCreateDate = DateTimePicker.GetDateTimeByTimeZone();
                    tripMemberDTO.FldConfirmation = "N";
                    Tbltripmember tbltripmember = _mapper.Map<Tbltripmember>(tripMemberDTO);
                    int id = await _tripMemberRepository.CreateTripMember(tbltripmember);
                    if (id > 0)
                    {
                        TbluserVO tbluserdetail = await _userDetailRepository.GetUserDetailById(tripMemberDTO.FldUserId);
                        TbluserVO tripPresenter = await _userDetailRepository.GetTripPresenterByTripId(tripMemberDTO.FldTripId);
                        int memberId = await _tripMemberRepository.GetLastOneId();
                        await EmailService.SendEmail(tripPresenter.FldFullname, tbluserdetail.FldEmail, tbluserdetail.FldFullname, memberId);
                        await _tripMemberRepository.UpdateSendMailDate(memberId);
                        return id;
                    }
                }
                else
                {
                    throw new InsertException("Tài khoản này đã tồn tại trong chuyến đi");
                }
                throw new InsertException("Đăng kí thành viên thất bại!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<int> UpdateTripMember(TripMemberDTO tripMemberDTO, CurrentUserObj currentUser)
        {
            try
            {
                TripMemberDTO getTrip = await GetTripMemberById((int)tripMemberDTO.FldMemberId);

                if (getTrip != null)
                {
                    if (await _tripMemberRepository.CountTripMemberByUserIdAndTripId(tripMemberDTO.FldUserId, tripMemberDTO.FldTripId) == 0)
                    {
                        tripMemberDTO.FldUpdateBy = currentUser.UserId;
                        tripMemberDTO.FldUpdateDate = DateTimePicker.GetDateTimeByTimeZone();
                        Tbltripmember tbltripmember = _mapper.Map<Tbltripmember>(tripMemberDTO);
                        if (await _tripMemberRepository.UpdateTripMember(tbltripmember) > 0)
                        {
                            return (int)tripMemberDTO.FldMemberId;
                        }
                        else
                        {
                            throw new UpdateException("Cập nhật thành viên thất bại");
                        }
                    }
                    else
                    {
                        throw new InsertException("Tài khoản này đã tồn tại trong chuyến đi");
                    }
                    throw new InsertException("Đăng kí thành viên thất bại!");
                }
                else
                {
                    throw new GetOneException("Thành viên này không tồn tại trong chuyến đi");
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
                        throw new DeleteException("Xoá thành viên thất bại!");
                    }

                }
                else
                {
                    throw new GetOneException("Thành viên này không tồn tại trong chuyến đi!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<int> SendMail(int id)
        {
            try
            {
                TripMemberDTO getTrip = await GetTripMemberById(id);

                if (getTrip != null)
                {
                    if(getTrip.FldConfirmation.Equals("N"))
                    {
                        TbluserVO tbluserdetail = await _userDetailRepository.GetUserDetailById(getTrip.FldUserId);
                        TbluserVO tripPresenter = await _userDetailRepository.GetTripPresenterByTripId(getTrip.FldTripId);
                        int memberId = await _tripMemberRepository.GetLastOneId();
                        await EmailService.SendEmail(tripPresenter.FldFullname, tbluserdetail.FldEmail, tbluserdetail.FldFullname, memberId);
                        await _tripMemberRepository.UpdateSendMailDate(id);
                        return id;
                    }
                    else
                    {
                        throw new UpdateException("Thành viên này đã tham gia chuyến đi!");
                    }
                }
                else
                {
                    throw new GetOneException("Thành viên này không tồn tại trong chuyến đi!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<int> ConfirmTrip(int id)
        {
            try
            {
                TripMemberDTO getTrip = await GetTripMemberById(id);

                if (getTrip != null)
                {
                    if (getTrip.FldConfirmation.Equals("N"))
                    {
                        if (await _tripMemberRepository.ConfirmTrip(id) > 0)
                        {
                            return id;
                        }
                        else
                        {
                            throw new UpdateException("Xác thực thất bại!");
                        }
                    }
                    else
                    {
                        throw new UpdateException("Đường dẫn này không hợp lệ! Vui lòng thử lại sau");
                    }
                }
                else
                {
                    throw new GetOneException("Thành viên này không tồn tại trong chuyến đi!");
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
