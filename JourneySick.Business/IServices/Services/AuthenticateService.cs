using AutoMapper;
using JourneySick.Business.Helpers;
using JourneySick.Business.Helpers.Exceptions;
using JourneySick.Business.Helpers.SettingObject;
using JourneySick.Business.Security;
using JourneySick.Data.IRepositories;
using JourneySick.Data.Models.DTOs.CommonDTO.Request;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;
using JourneySick.Data.Models.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RevenueSharingInvest.Business.Services.Extensions.Email;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Business.IServices.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly IUserDetailRepository _userDetailRepository;
        private readonly AppSecrect _appSecrect;
        private readonly ILogger<AuthenticateService> _logger;
        private readonly IMapper _mapper;

        public AuthenticateService(IUserService userService,
            IUserDetailRepository userDetailRepository,
            IUserRepository userRepository,
            IOptions<AppSecrect> appSecrect,
            ILogger<AuthenticateService> logger, IMapper mapper)
        {
            _userService = userService;
            _appSecrect = appSecrect.Value;
            _userRepository = userRepository;
            _userDetailRepository = userDetailRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<RegisterResponse> RegisterUser(RegisterRequest registereRequest)
        {
            try
            {
                UserVO userDetailEntity = new();
                RegisterResponse registerResponse = new();
                string checkNameExist = await _userRepository.GetUsernameIfExist(registereRequest.Username);
                if (checkNameExist != null)
                {
                    throw new UserAlreadyExistException("Tên đăng nhập này đã được sử dụng!!");
                }
                string checkEmailExist = await _userDetailRepository.GetEmailIfExist(registereRequest.Email);
                if (checkEmailExist != null)
                {
                    throw new UserAlreadyExistException("Địa chỉ email này đã được sử dụng!!");
                }
                string checkPhoneExist = await _userDetailRepository.GetPhoneIfExist(registereRequest.Phone);
                if (checkPhoneExist != null)
                {
                    throw new UserAlreadyExistException("Số điện thoại này đã được sử dụng!!");
                }
                userDetailEntity.UserId = await GenerateUserID();
                userDetailEntity.Username = registereRequest.Username;
                userDetailEntity.Password = PasswordEncryption.Encrypt(registereRequest.Password, _appSecrect.SecrectKey);
                await EmailService.SendEmailRegister(userDetailEntity.Email, userDetailEntity.Fullname);
                userDetailEntity.SendDate = DateTimePicker.GetDateTimeByTimeZone();

                if (await _userRepository.CreateUser(userDetailEntity) > 0)
                {
                    userDetailEntity.Role = UserRoleEnum.USER.ToString();
                    //userDetailEntity.Birthday = Convert.ToDateTime(registereRequest.Birthday, CultureInfo.InvariantCulture);
                    userDetailEntity.ActiveStatus = "ACTIVE";
                    userDetailEntity.Email = registereRequest.Email;
                    userDetailEntity.Fullname = registereRequest.FirstName + " " + registereRequest.LastName;
                    userDetailEntity.Phone = registereRequest.Phone;
                    userDetailEntity.Address = registereRequest.Address;
                    userDetailEntity.Experience = 0;
                    userDetailEntity.TripCreated = 0;
                    userDetailEntity.TripJoined = 0;
                    userDetailEntity.TripCompleted = 0;
                    userDetailEntity.TripCancelled = 0;
                    userDetailEntity.CreateDate = DateTimePicker.GetDateTimeByTimeZone();
                    userDetailEntity.CreateBy = userDetailEntity.UserId;
                    if (await _userDetailRepository.CreateUserDetail(userDetailEntity) < 1)
                    {
                        throw new RegisterUserException("Đăng kí thất bại!!");
                    }
                }
                registerResponse.Email = registereRequest.Email;
                registerResponse.FullName = userDetailEntity.Fullname;
                registerResponse.Username = registereRequest.Username;
                registerResponse.Token = await GenerateTokenAsync(UserRoleEnum.USER.ToString(), userDetailEntity.UserId, name: userDetailEntity.Fullname);

                return registerResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }

        }

        public async Task<LoginResponse> LoginUser(LoginRequest loginRequest)
        {
            try
            {
                LoginResponse loginResponse = new();
                string checkValue = await _userRepository.GetPasswordByUsername(loginRequest.Username);
                if (false)
                {
                    throw new LoginFailedException("Tài khoản hoặc mật khẩu không đúng!!");
                }
                else
                {

                    string encryptedPassword = PasswordEncryption.Encrypt(loginRequest.Password, _appSecrect.SecrectKey);
                    if (encryptedPassword.Equals(checkValue))
                    {
                        UserVO userVO = await _userRepository.GetUserByUsername(loginRequest.Username);
                        if (userVO.Confirmation.Equals("N"))
                        {
                            // note: cheeck thêm đk sendDate
                            if(userVO.Role.Equals(UserRoleEnum.USER.ToString()) && DateTime.Compare(userVO.SendDate.AddMinutes(30), DateTimePicker.GetDateTimeByTimeZone()) < 0)
                            {
                                await EmailService.SendEmailRegister(userVO.Email, userVO.Fullname);
                            }
                            throw new LoginFailedException("Vui lòng xác thực email của bạn!!");
                        }
                        UserRequest userRequest = _mapper.Map<UserRequest>(userVO);
                        loginResponse.Token = await GenerateTokenAsync(roleCheck: userVO.Role, userId: userVO.UserId, name: userVO.Fullname);
                        CurrentUserRequest currentUser = new();
                        currentUser.Name = userRequest.Fullname;
                        currentUser.Role = userRequest.Role;
                        currentUser.UserId = userRequest.UserId;
                        loginResponse.CurrentUserObj = currentUser;
                    }
                    else
                    {
                        throw new LoginFailedException("Tài khoản hoặc mật khẩu không đúng!!");
                    }
                }

                return loginResponse;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            try
            {
                LoginResponse loginResponse = new();
                string checkValue = await _userRepository.GetPasswordByUsername(loginRequest.Username);
                if (string.IsNullOrEmpty(checkValue))
                {
                    throw new LoginFailedException("Tài khoản hoặc mật khẩu không đúng!!");
                }
                else
                {

                    string encryptedPassword = PasswordEncryption.Encrypt(loginRequest.Password, _appSecrect.SecrectKey);
                    if (encryptedPassword.Equals(checkValue))
                    {
                        UserVO userVO = await _userRepository.GetUserByUsername(loginRequest.Username);
                        if(userVO != null)
                        {
                            if (userVO.Role.Equals(UserRoleEnum.ADMIN.ToString()) || userVO.Role.Equals(UserRoleEnum.EMPL.ToString()))
                            {
                                UserRequest userRequest = _mapper.Map<UserRequest>(userVO);
                                loginResponse.Token = await GenerateTokenAsync(roleCheck: userVO.Role, userId: userVO.UserId, name: userVO.Fullname);
                                CurrentUserRequest currentUser = new();
                                currentUser.Name = userRequest.Fullname;
                                currentUser.Role = userRequest.Role;
                                currentUser.UserId = userRequest.UserId;
                                loginResponse.CurrentUserObj = currentUser;
                            }
                            else
                            {
                                throw new LoginFailedException("You do not have permission to access!!");
                            }

                        }
                        else
                        {
                            throw new LoginFailedException("Your account may be not existed or be banned!!");
                        }
                    }
                    else
                    {
                        throw new LoginFailedException("Tài khoản hoặc mật khẩu không đúng!!");
                    }
                }

                return loginResponse;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<UserRequest> GetCurrentInfo(CurrentUserRequest currentUser)
        {
            try
            {
                UserVO UserVO = await _userRepository.GetUserById(currentUser.UserId);
                // convert entity to dto
                UserRequest userVO = _mapper.Map<UserRequest>(UserVO);

                return userVO;
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.StackTrace, ex);
                throw;
            }
        }

        private async Task<string> GenerateTokenAsync(string roleCheck, string userId, string name)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSecrect.JwtSecrect);

                Claim roleClaim;

                if (roleCheck.Equals(UserRoleEnum.ADMIN.ToString()))
                {
                    roleClaim = new Claim(ClaimTypes.Role, UserRoleEnum.ADMIN.ToString());

                }
                else
                {
                    roleClaim = new Claim(ClaimTypes.Role, UserRoleEnum.EMPL.ToString());

                }

                int hours;

                if (roleCheck.Equals(UserRoleEnum.ADMIN.ToString()))
                {
                    hours = 3;
                }
                else
                {
                    hours = 5;
                }

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.SerialNumber, userId),
                        new Claim(ClaimTypes.Name, name),
                        roleClaim

                    }),

                    Expires = DateTime.UtcNow.AddHours(hours),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                string result = tokenHandler.WriteToken(token);
                return result;
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
    }
}
