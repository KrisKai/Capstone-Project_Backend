using AutoMapper;
using JourneySick.Business.Helpers;
using JourneySick.Business.Helpers.Exceptions;
using JourneySick.Business.Models.DTOs;
using JourneySick.Business.Security;
using JourneySick.Data.IRepositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;
using JourneySick.Data.Models.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
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

                UserVO userDTO = new();
                TbluserVO userDetailEntity = new();
                RegisterResponse registerResponse = new();
                string checkNameExist = await _userRepository.GetUsernameIfExist(registereRequest.Username);
                if (checkNameExist != null)
                {
                    throw new UserAlreadyExistException("User With This Username Already Exist!!");
                }
                userDTO.FldUsername = registereRequest.Username;
                userDTO.FldPassword = PasswordEncryption.Encrypt(registereRequest.Password, _appSecrect.SecrectKey);
                //userDTO.FldUserId = await _userService.CreateUser(userDTO);
                if (!userDTO.FldUserId.Equals(""))
                {
                    userDetailEntity.FldUserId = userDTO.FldUserId;
                    userDetailEntity.FldRole = UserRoleEnum.USER.ToString();
                    userDetailEntity.FldBirthday = Convert.ToDateTime(registereRequest.Birthdate, CultureInfo.InvariantCulture);
                    userDetailEntity.FldActiveStatus = "Active";
                    userDetailEntity.FldEmail = registereRequest.Email;
                    userDetailEntity.FldFullname = registereRequest.FirstName + " " + registereRequest.LastName;
                    userDetailEntity.FldPhone = registereRequest.Phone;
                    userDetailEntity.FldAddress = registereRequest.Address;
                    userDetailEntity.FldAddress = registereRequest.Address;
                    userDetailEntity.FldExperience = 0;
                    userDetailEntity.FldTripCreated = 0;
                    userDetailEntity.FldTripJoined = 0;
                    userDetailEntity.FldTripCompleted = 0;
                    userDetailEntity.FldTripCancelled = 0;
                    userDetailEntity.FldCreateDate = DateTimePicker.GetDateTimeByTimeZone();
                    userDetailEntity.FldCreateBy = userDTO.FldUserId;
                    userDetailEntity.FldUpdateBy = userDTO.FldUserId;
                    userDetailEntity.FldUpdateDate = DateTimePicker.GetDateTimeByTimeZone();
                    if (await _userDetailRepository.CreateUserDetail(userDetailEntity) < 1)
                    {
                        throw new RegisterUserException("Register Failed!!");
                    }
                }
                registerResponse.Email = registereRequest.Email;
                registerResponse.FullName = userDetailEntity.FldFullname;
                registerResponse.Username = registereRequest.Username;
                registerResponse.Token = await GenerateTokenAsync(UserRoleEnum.USER.ToString(), userDTO.FldUserId, name: userDTO.FldFullname);

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
                if (string.IsNullOrEmpty(checkValue))
                {
                    throw new LoginFailedException("Username Or Password Not Exist!!");
                }
                else
                {

                    string encryptedPassword = PasswordEncryption.Encrypt(loginRequest.Password, _appSecrect.SecrectKey);
                    if (encryptedPassword.Equals(checkValue))
                    {
                        TbluserVO tbluserVO = await _userRepository.GetUserByUsername(loginRequest.Username);
                        if (tbluserVO.FldRole.Equals(UserRoleEnum.ADMIN.ToString()) || tbluserVO.FldRole.Equals(UserRoleEnum.EMPL.ToString()))
                        {
                            UserVO userVO = _mapper.Map<UserVO>(tbluserVO);
                            loginResponse.Token = await GenerateTokenAsync(roleCheck: userVO.FldRole, userId: userVO.FldUserId, name: userVO.FldFullname);
                            CurrentUserObj currentUser = new();
                            currentUser.Name = userVO.FldFullname;
                            currentUser.Role = userVO.FldRole;
                            currentUser.UserId = userVO.FldUserId;
                            loginResponse.CurrentUserObj = currentUser;
                        }
                        else
                        {
                            throw new LoginFailedException("You do not have permission to access!!");
                        }
                    }
                    else
                    {
                        throw new LoginFailedException("Username Or Password Not Exist!!");
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
                    roleClaim = new Claim(ClaimTypes.Role, UserRoleEnum.USER.ToString());

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




    }
}
