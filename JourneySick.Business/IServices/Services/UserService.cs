using AutoMapper;
using JourneySick.Business.Helpers;
using JourneySick.Business.Helpers.Exceptions;
using JourneySick.Business.Helpers.SettingObject;
using JourneySick.Business.Models.DTOs;
using JourneySick.Business.Security;
using JourneySick.Data.IRepositories;
using JourneySick.Data.IRepositories.Repositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;
using JourneySick.Data.Models.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace JourneySick.Business.IServices.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserDetailRepository _userDetailRepository;
        private readonly ITripMemberRepository _tripMemberRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        private readonly AppSecrect _appSecrect;

        public UserService(IUserRepository userRepository, IUserDetailRepository userDetailRepository, ITripMemberRepository tripMemberRepository, IOptions<AppSecrect> appSecrect, IMapper mapper, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _userDetailRepository = userDetailRepository;
            _tripMemberRepository = tripMemberRepository;
            _appSecrect = appSecrect.Value;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<AllUserDTO> GetAllUsersWithPaging(int pageIndex, int pageSize, string? userName, CurrentUserObj currentUser)
        {
            AllUserDTO result = new();
            try
            {
                List<Data.Models.Entities.VO.UserVO> users = await _userRepository.GetAllUsersWithPaging(pageIndex, pageSize, userName, currentUser.Role);
                // convert entity to dto
                List<Data.Models.DTOs.CommonDTO.VO.UserVO> users = _mapper.Map<List<Data.Models.DTOs.CommonDTO.VO.UserVO>>(users);
                int count = await _userRepository.CountAllUsers(userName, currentUser.Role);
                result.ListOfUser = users;
                result.NumOfUser = count;
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Data.Models.DTOs.CommonDTO.VO.UserVO> GetUserById(string userId)
        {
            try
            {
                Data.Models.Entities.VO.UserVO UserVO = await _userRepository.GetUserById(userId);
                // convert entity to dto
                Data.Models.DTOs.CommonDTO.VO.UserVO userVO = _mapper.Map<Data.Models.DTOs.CommonDTO.VO.UserVO>(UserVO);

                return userVO;
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.StackTrace, ex);
                throw;
            }

        }

        public async Task<string> CreateUser(Data.Models.DTOs.CommonDTO.VO.UserVO userVO, CurrentUserObj currentUser)
        {
            try
            {
                // validate
                if (await ValidateUserCreate(userVO) == 0)
                {
                    // generate ID (format: USER00000000)
                    userVO.UserId = await GenerateUserID();
                    userVO.Password = PasswordEncryption.Encrypt(userVO.Password, _appSecrect.SecrectKey);
                    userVO.ActiveStatus = "ACTIVE";
                    userVO.CreateBy = currentUser.UserId;
                    userVO.CreateDate = DateTimePicker.GetDateTimeByTimeZone();
                    Data.Models.Entities.VO.UserVO userEntity = _mapper.Map<Data.Models.Entities.VO.UserVO>(userVO);
                    if (await _userRepository.CreateUser(userEntity) > 0 && await _userDetailRepository.CreateUserDetail(userEntity) > 0)
                    {
                        return userEntity.UserId;
                    }
                }
                throw new InsertException("Create user failed!");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<string> UpdateUser(Data.Models.DTOs.CommonDTO.VO.UserVO userVO, CurrentUserObj currentUser)
        {
            try
            {
                Data.Models.DTOs.CommonDTO.VO.UserVO getTrip = await GetUserById(userId: userVO.UserId);

                if (getTrip != null && await ValidateUserUpdate(getTrip, userVO) == 0)
                {
                    userVO.UpdateBy = currentUser.UserId;
                    userVO.UpdateDate = DateTimePicker.GetDateTimeByTimeZone();
                    Data.Models.Entities.VO.UserVO userVO = _mapper.Map<Data.Models.Entities.VO.UserVO>(userVO);
                    if (await _userDetailRepository.UpdateUserDetail(userVO) > 0)
                    {
                        return userVO.UserId;
                    }
                    else
                    {
                        throw new UpdateException("Update user failed!");
                    }
                }
                else
                {
                    throw new GetOneException("User is not existed!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<int> DeleteUser(string userId)
        {
            try
            {
                Data.Models.DTOs.CommonDTO.VO.UserVO getTrip = await GetUserById(userId);

                if (getTrip != null)
                {
                    if (await _userRepository.DeleteUser(userId) > 0 && await _userDetailRepository.DeleteUserDetail(userId) > 0)
                    {
                        await _tripMemberRepository.DeleteTripMemberByUserId(userId);
                        return 1;
                    }
                    else
                    {
                        throw new DeleteException("Delete user failed!");
                    }

                }
                else
                {
                    throw new GetOneException("User is not existed!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        private async Task<string> GenerateUserID()
        {
            try
            {
                string lastOne = await _userRepository.GetLastOneId();
                if (lastOne != null)
                {
                    string lastId = lastOne.Substring(5);
                    int newId = Convert.ToInt32(lastId) + 1;
                    string newIdStr = Convert.ToString(newId);
                    while (newIdStr.Length < 8)
                    {
                        newIdStr = "0" + newIdStr;
                    }
                    return "USER_" + newIdStr;
                }
                else
                {
                    return "USER_00000001";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }

        }

        public async Task<int> ResetPassword(string? id, CurrentUserObj currentUser)
        {
            if (currentUser.Role.Equals(UserRoleEnum.ADMIN.ToString()))
            {
                try
                {
                    // reset password to Qwe1234!
                    string newPassword = PasswordEncryption.Encrypt("Qwe1234!", _appSecrect.SecrectKey);
                    if (await _userRepository.ChangePassword(id, newPassword) > 0)
                    {
                        return 1;
                    }
                    return 0;
                }
                catch
                {
                    throw new UpdateException("Reset Failed!!");
                }
            }
            throw new PermissionException("You do not have permission to access!!");
        }

        public async Task<int> ChangePassword(ChangePasswordDTO changePasswordDTO)
        {
            try
            {
                Data.Models.Entities.VO.UserVO userVO = await _userRepository.GetUserById(changePasswordDTO.UserId);
                Data.Models.DTOs.CommonDTO.VO.UserVO userVO = _mapper.Map<Data.Models.DTOs.CommonDTO.VO.UserVO>(userVO);
                if (userVO != null && userVO.Password.Equals(PasswordEncryption.Encrypt(changePasswordDTO.OldPassword, _appSecrect.SecrectKey)))
                {
                    string newPassword = PasswordEncryption.Encrypt(changePasswordDTO.Password, _appSecrect.SecrectKey);
                    if (await _userRepository.ChangePassword(changePasswordDTO.UserId, newPassword) > 0)
                    {
                        return 1;
                    }
                    throw new UpdateException("Change Password Failed!!");
                }
                throw new UpdateException("Your Password is not correct!!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<int> UpdateAcitveStatus(Data.Models.DTOs.CommonDTO.VO.UserVO userVO, CurrentUserObj currentUser)
        {
            if (currentUser.Role.Equals(UserRoleEnum.ADMIN.ToString()))
            {
                try
                {
                    Data.Models.Entities.VO.UserVO userVO = _mapper.Map<Data.Models.Entities.VO.UserVO>(userVO);
                    Data.Models.Entities.VO.UserVO getUser = await _userRepository.GetUserById(userVO.UserId);
                    if(getUser != null)
                    {
                        if (getUser.ActiveStatus.Equals("ACTIVE"))
                        {
                            TripmemberVO tripmemberVO = new();
                            tripmemberVO.UserId = userVO.UserId;
                            tripmemberVO.Status = userVO.ActiveStatus;
                            await _tripMemberRepository.UpdateMemberStatus(tripmemberVO);
                        }
                        if (await _userDetailRepository.UpdateAcitveStatus(userVO) > 0)
                        {
                            return 1;
                        }
                        return 0;
                    }
                    
                }
                catch
                {
                    throw new UpdateException("Change status Failed!!");
                }
            }
            throw new PermissionException("You do not have permission to access!!");
        }

        private async Task<int> ValidateUserCreate(Data.Models.DTOs.CommonDTO.VO.UserVO userVO)
        {
            string username = await _userRepository.GetUsernameIfExist(userVO.Username);
            string email = await _userDetailRepository.GetEmailIfExist(userVO.Email);
            string phone = await _userDetailRepository.GetPhoneIfExist(userVO.Phone);
            if (!string.IsNullOrEmpty(username))
            {
                throw new ValidateException("Username is Existed!");
            }
            else if (!string.IsNullOrEmpty(email))
            {
                throw new ValidateException("Email is Existed!");
            }
            else if (!string.IsNullOrEmpty(phone))
            {
                throw new ValidateException("Phone is is Existed!");
            }
            return 0;
        }

        private async Task<int> ValidateUserUpdate(Data.Models.DTOs.CommonDTO.VO.UserVO oldUser, Data.Models.DTOs.CommonDTO.VO.UserVO newUser)
        {
            if (!oldUser.Username.Equals(newUser.Username))
            {
                string username = await _userRepository.GetUsernameIfExist(newUser.Username);
                if (!string.IsNullOrEmpty(username))
                {
                    throw new ValidateException("Username is Existed!");
                }
            }
            if (!oldUser.Email.Equals(newUser.Email))
            {
                string email = await _userDetailRepository.GetEmailIfExist(newUser.Email);


                if (!string.IsNullOrEmpty(email))
                {
                    throw new ValidateException("Email is Existed!");
                }
            }
            if (!oldUser.Phone.Equals(newUser.Phone))
            {
                string phone = await _userDetailRepository.GetPhoneIfExist(newUser.Phone);
                if (!string.IsNullOrEmpty(phone))
                {
                    throw new ValidateException("Phone is is Existed!");
                }
            }

            return 0;
        }

    }
}
