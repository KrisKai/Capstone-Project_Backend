using AutoMapper;
using JourneySick.Business.Helpers;
using JourneySick.Business.Helpers.Exceptions;
using JourneySick.Data.IRepositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.Request;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;
using Microsoft.Extensions.Logging;
using RevenueSharingInvest.Business.Services.Extensions.Email;

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

        public async Task<AllTripMemberDTO> GetAllTripMembersWithPaging(int pageIndex, int pageSize, string tripId, string? memberName)
        {
            AllTripMemberDTO result = new();
            try
            {
                List<TripmemberVO> tripmembers = await _tripMemberRepository.GetAllTripMembersWithPaging(pageIndex, pageSize, tripId, memberName);
                // convert entity to dto
                List<TripMemberRequest> tripMemberDTOs = _mapper.Map<List<TripMemberRequest>>(tripmembers);
                int count = await _tripMemberRepository.CountAllTripMembers(tripId, memberName);
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

        public async Task<TripMemberRequest> GetTripMemberById(int memberId)
        {
            try
            {
                TripmemberVO tripmember = await _tripMemberRepository.GetTripMemberById(memberId);
                // convert entity to dto
                TripMemberRequest tripMemberDTO = _mapper.Map<TripMemberRequest>(tripmember);

                return tripMemberDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<int> CreateTripMember(TripMemberDTO tripMemberDTO, CurrentUserObject currentUser)
        {
            try
            {
                if (await _tripMemberRepository.CountTripMemberByUserIdAndTripId(tripMemberDTO.UserId, tripMemberDTO.TripId) == 0)
                {
                    tripMemberDTO.CreateBy = currentUser.UserId;
                    tripMemberDTO.CreateDate = DateTimePicker.GetDateTimeByTimeZone();
                    tripMemberDTO.Confirmation = "N";
                    TripMember tripmember = _mapper.Map<TripMember>(tripMemberDTO);
                    int id = (int)await _tripMemberRepository.CreateTripMember(tripmember);
                    if (id > 0)
                    {
                        UserVO userdetail = await _userDetailRepository.GetUserDetailById(tripMemberDTO.UserId);
                        UserVO tripPresenter = await _userDetailRepository.GetTripPresenterByTripId(tripMemberDTO.TripId);
                        await EmailService.SendEmailTrip(tripPresenter.Fullname, userdetail.Email, userdetail.Fullname, id);
                        await _tripMemberRepository.UpdateSendMailDate(id);
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

        public async Task<int> UpdateTripMember(TripMemberDTO tripMemberDTO, CurrentUserObject currentUser)
        {
            try
            {
                TripMemberDTO getTrip = await GetTripMemberById((int)tripMemberDTO.MemberId);

                if (getTrip != null)
                {
                    if (await _tripMemberRepository.CountTripMemberByUserIdAndTripId(tripMemberDTO.UserId, tripMemberDTO.TripId) > 0 && getTrip.UserId.Equals(tripMemberDTO.UserId))
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
                        UserVO userdetail = await _userDetailRepository.GetUserDetailById(getTrip.UserId);
                        UserVO tripPresenter = await _userDetailRepository.GetTripPresenterByTripId(getTrip.TripId);
                        await EmailService.SendEmailTrip(tripPresenter.Fullname, userdetail.Email, userdetail.Fullname, id);
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
