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
                List<TripmemberVO> tripmembers = await _tripMemberRepository.GetAllTripMembersWithPaging(pageIndex, pageSize, memberName);
                // convert entity to dto
                List<TripMemberVO> tripMemberDTOs = _mapper.Map<List<TripMemberVO>>(tripmembers);
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
                TripmemberVO tripmember = await _tripMemberRepository.GetTripMemberById(memberId);
                // convert entity to dto
                TripMemberVO tripMemberDTO = _mapper.Map<TripMemberVO>(tripmember);

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
                if (await _tripMemberRepository.CountTripMemberByUserIdAndTripId(tripMemberDTO.UserId, tripMemberDTO.TripId) == 0)
                {
                    tripMemberDTO.CreateBy = currentUser.UserId;
                    tripMemberDTO.CreateDate = DateTimePicker.GetDateTimeByTimeZone();
                    tripMemberDTO.Confirmation = "N";
                    TripMember tripmember = _mapper.Map<TripMember>(tripMemberDTO);
                    int id = await _tripMemberRepository.CreateTripMember(tripmember);
                    if (id > 0)
                    {
                        Data.Models.Entities.VO.UserVO userdetail = await _userDetailRepository.GetUserDetailById(tripMemberDTO.UserId);
                        Data.Models.Entities.VO.UserVO tripPresenter = await _userDetailRepository.GetTripPresenterByTripId(tripMemberDTO.TripId);
                        int memberId = await _tripMemberRepository.GetLastOneId();
                        await EmailService.SendEmailTrip(tripPresenter.Fullname, userdetail.Email, userdetail.Fullname, memberId);
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
                TripMemberDTO getTrip = await GetTripMemberById((int)tripMemberDTO.MemberId);

                if (getTrip != null)
                {
                    if (await _tripMemberRepository.CountTripMemberByUserIdAndTripId(tripMemberDTO.UserId, tripMemberDTO.TripId) == 0)
                    {
                        tripMemberDTO.UpdateBy = currentUser.UserId;
                        tripMemberDTO.UpdateDate = DateTimePicker.GetDateTimeByTimeZone();
                        TripMember tripmember = _mapper.Map<TripMember>(tripMemberDTO);
                        if (await _tripMemberRepository.UpdateTripMember(tripmember) > 0)
                        {
                            return (int)tripMemberDTO.MemberId;
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
                    if(getTrip.Confirmation.Equals("N"))
                    {
                        Data.Models.Entities.VO.UserVO userdetail = await _userDetailRepository.GetUserDetailById(getTrip.UserId);
                        Data.Models.Entities.VO.UserVO tripPresenter = await _userDetailRepository.GetTripPresenterByTripId(getTrip.TripId);
                        int memberId = await _tripMemberRepository.GetLastOneId();
                        await EmailService.SendEmailTrip(tripPresenter.Fullname, userdetail.Email, userdetail.Fullname, memberId);
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
                    if (getTrip.Confirmation.Equals("N"))
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
