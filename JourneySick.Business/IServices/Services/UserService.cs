using AutoMapper;
using JourneySick.Business.Helpers;
using JourneySick.Business.Security;
using JourneySick.Data.IRepositories;
using JourneySick.Data.IRepositories.Repositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;
using JourneySick.Data.Models.VO;
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

        public async Task<int> CreateUser(UserVO userVO)
        {
            try
            {
                // generate ID (format: USER00000000)
                userVO.FldUserId = await GenerateUserID();
                Tbluser tbluser = ConvertUserVOToTblUser(userVO);
                tbluser.FldPassword = PasswordEncryption.Encrypt(tbluser.FldPassword, _appSecrect.SecrectKey);
                int id = await _userRepository.CreateUser(tbluser);
                Tbluserdetail tbluserdetail = ConvertUserVOToTblUserDetail(userVO);
                tbluserdetail.FldActiveStatus = "Active";
                tbluserdetail.FldCreateBy = "Admin";
                tbluserdetail.FldCreateDate = DateTime.Now;
                await _userDetailRepository.CreateUserDetail(tbluserdetail);
                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserVO> GetUserById(string userId)
        {
            try
            {
                TbluserVO tblUserVO = await _userRepository.GetUserById(userId);
                // convert entity to dto
                UserVO userDTO = _mapper.Map<UserVO>(tblUserVO);
                return userDTO;
            }
            catch(Exception ex)
            {
                _logger.LogError(message: ex.StackTrace, ex);
                throw new Exception(ex.Message);
            }

        }

        public async Task<string> UpdateUser(UserVO userDTO)
        {
            try
            {
                // convert entity to dto
                Tbluser tblUser = _mapper.Map<Tbluser>(userDTO);
                return userDTO.FldUserId;
            }
            catch (Exception ex)
            {
                throw new Exception();
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
            catch(Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw new Exception(ex.Message);
            }

        }

        private Tbluser ConvertUserVOToTblUser(UserVO userVO)
        {
            UserDTO userDTO = new()
            {
                FldUserId = userVO.FldUserId,
                FldUsername = userVO.FldUsername,
                FldPassword = userVO.FldPassword
            };

            Tbluser tbluser = _mapper.Map<Tbluser>(userDTO);
            return tbluser;
        }

        private Tbluserdetail ConvertUserVOToTblUserDetail(UserVO userVO)
        {
            UserDetailDTO userDetailDTO = new()
            {
                FldUserId = userVO.FldUserId,
                FldFullname = userVO.FldFullname,
                FldAddress = userVO.FldAddress,
                FldRole = userVO.FldRole,
                FldPhone = userVO.FldPhone,
                FldEmail = userVO.FldEmail,
                FldBirthday = userVO.FldBirthday
            };

            Tbluserdetail tbluserDetail = _mapper.Map<Tbluserdetail>(userDetailDTO);
            return tbluserDetail;
        }

        public async Task<int> DeleteUser(string userId)
        {
            try
            {
                UserVO getTrip = await GetUserById(userId);

                if (getTrip != null)
                {
                    int id = await _userRepository.DeleteUser(userId);
                    return id;
                }
                else
                {
                    return 0;
                }
            } catch(Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw new Exception(ex.Message);
            }
        }
    }
}
