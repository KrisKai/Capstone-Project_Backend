﻿using JourneySick.Business.Helpers;
using JourneySick.Business.Helpers.Exceptions;
using JourneySick.Business.Security;
using JourneySick.Data.IRepositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Enums;
using JourneySick.Data.Models.VO;
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

        public AuthenticateService(IUserService userService, 
            IUserDetailRepository userDetailRepository,
            IUserRepository userRepository,
            IOptions<AppSecrect> appSecrect,
            ILogger<AuthenticateService> logger)
        {
            _userService = userService;
            _appSecrect = appSecrect.Value;
            _userRepository = userRepository;
            _userDetailRepository = userDetailRepository;
            _logger = logger;
        }

        public async Task<RegisterResponse> RegisterUser(RegisterRequest registereRequest)
        {
            try
            {
                Tbluser userEntity = new();
                Tbluserdetail userDetailEntity = new(); 
                RegisterResponse registerResponse = new();
                string checkNameExist = await _userRepository.GetUsernameIfExist(registereRequest.Username);
                if(checkNameExist != null)
                {
                    throw new UserAlreadyExistException("User With This Username Already Exist!!");
                }
                userEntity.FldUsername = registereRequest.Username;
                userEntity.FldPassword = PasswordEncryption.Encrypt(registereRequest.Password, _appSecrect.SecrectKey);

                if( await _userRepository.CreateUser(userEntity) > 0)
                {
                    userDetailEntity.FldUserId = userEntity.FldUserId;
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
                    userDetailEntity.FldCreateBy = userEntity.FldUserId;
                    userDetailEntity.FldUpdateBy = userEntity.FldUserId;
                    userDetailEntity.FldUpdateDate = DateTimePicker.GetDateTimeByTimeZone();
                    if(await _userDetailRepository.CreateUserDetail(userDetailEntity) < 1)
                    {
                        throw new RegisterUserException("Register Failed!!");
                    }
                }
                registerResponse.Email = registereRequest.Email;
                registerResponse.FullName = userDetailEntity.FldFullname;
                registerResponse.Username = registereRequest.Username;
                registerResponse.Token = await GenerateTokenAsync(UserRoleEnum.USER.ToString(), userEntity.FldUserId);

                return registerResponse;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw new RegisterUserException("Register Failed!!");
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
                    if(encryptedPassword.Equals(checkValue))
                    {
                        UserVO userVO = await _userRepository.GetUserByUsername(loginRequest.Username);
                        loginResponse.Token = await GenerateTokenAsync(UserRoleEnum.USER.ToString(), userVO.FldUserId);
                        loginResponse.Username = userVO.FldUsername;
                        loginResponse.Fullname = userVO.FldUserId;
                    } else
                    {
                        throw new LoginFailedException("Username Or Password Not Exist!!");
                    }
                }

                return loginResponse;

            }catch(Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw new Exception(ex.Message);
            }
        }

        private async Task<string> GenerateTokenAsync(string roleCheck, string userId)
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
                    hours = 24;
                }

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                   new Claim(ClaimTypes.SerialNumber, userId),
                   roleClaim,
                    }),

                    Expires = DateTime.UtcNow.AddHours(hours),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                string result = tokenHandler.WriteToken(token);
                return result;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw new Exception(ex.ToString());
            }
        }



    }
}
