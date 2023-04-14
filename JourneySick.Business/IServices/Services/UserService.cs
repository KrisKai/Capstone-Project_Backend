using AutoMapper;
using JourneySick.Business.Helpers;
using JourneySick.Business.Helpers.Exceptions;
using JourneySick.Business.Models.DTOs;
using JourneySick.Business.Security;
using JourneySick.Data.IRepositories;
using JourneySick.Data.IRepositories.Repositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace JourneySick.Business.IServices.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserDetailRepository _userDetailRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        private readonly AppSecrect _appSecrect;

        public UserService(IUserRepository userRepository, IUserDetailRepository userDetailRepository, IOptions<AppSecrect> appSecrect, IMapper mapper, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _userDetailRepository = userDetailRepository;
            _appSecrect = appSecrect.Value;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<AllUserDTO> GetAllUsersWithPaging(int pageIndex, int pageSize, string? userName, CurrentUserObj currentUser)
        {
            AllUserDTO result = new();
            try
            {
                List<TbluserVO> tblusers = await _userRepository.GetAllUsersWithPaging(pageIndex, pageSize, userName, currentUser.Role);
                // convert entity to dto
                List<UserVO> users = _mapper.Map<List<UserVO>>(tblusers);
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

        public async Task<UserVO> GetUserById(string userId)
        {
            try
            {
                TbluserVO tblUserVO = await _userRepository.GetUserById(userId);
                // convert entity to dto
                UserVO userVO = _mapper.Map<UserVO>(tblUserVO);

                return userVO;
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.StackTrace, ex);
                throw;
            }

        }

        public async Task<string> CreateUser(UserVO userVO, CurrentUserObj currentUser)
        {
            try
            {
                // validate
                if(await ValidateUser(userVO) == 0)
                {
                    // generate ID (format: USER00000000)
                    userVO.FldUserId = await GenerateUserID();
                    userVO.FldPassword = PasswordEncryption.Encrypt(userVO.FldPassword, _appSecrect.SecrectKey);
                    userVO.FldActiveStatus = "ACTIVE";
                    userVO.FldCreateBy = currentUser.UserId;
                    userVO.FldCreateDate = DateTime.Now;
                    TbluserVO userEntity = _mapper.Map<TbluserVO>(userVO);
                    if (await _userRepository.CreateUser(userEntity) > 0 && await _userDetailRepository.CreateUserDetail(userEntity) > 0)
                    {
                        return userEntity.FldUserId;
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

        public async Task<string> UpdateUser(UserVO userVO, CurrentUserObj currentUser)
        {
            try
            {
                UserVO getTrip = await GetUserById(userId: userVO.FldUserId);

                if (getTrip != null)
                {
                    userVO.FldUpdateBy = currentUser.UserId;
                    userVO.FldUpdateDate = DateTime.Now;
                    TbluserVO tbluserVO = _mapper.Map<TbluserVO>(userVO);
                    if (await _userDetailRepository.UpdateUserDetail(tbluserVO) > 0)
                    {
                        return userVO.FldUserId;
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
                UserVO getTrip = await GetUserById(userId);

                if (getTrip != null)
                {
                    if (await _userRepository.DeleteUser(userId) > 0 && await _userDetailRepository.DeleteUserDetail(userId) > 0)
                    {
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
                throw new Exception(ex.Message);
            }

        }

        private async Task<int> ValidateUser(UserVO userVO)
        {
            string username = await _userRepository.GetUsernameIfExist(userVO.FldUsername);
            string email = await _userDetailRepository.GetEmailIfExist(userVO.FldEmail);
            string phone = await _userDetailRepository.GetPhoneIfExist(userVO.FldPhone);
            if (!string.IsNullOrEmpty(username))
            {
                throw new ValidateException("Username is Existed!");
            } else if (!string.IsNullOrEmpty(email))
            {
                throw new ValidateException("Email is Existed!");
            } else if (!string.IsNullOrEmpty(phone)) 
            {
                throw new ValidateException("Phone is is Existed!");
            }
            return 0;
        }

    }
}
