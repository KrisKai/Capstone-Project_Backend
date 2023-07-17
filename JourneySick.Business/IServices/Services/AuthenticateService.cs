using AutoMapper;
using FirebaseAdmin.Auth;
using JourneySick.Business.Helpers;
using JourneySick.Business.Helpers.Exceptions;
using JourneySick.Business.Helpers.SettingObject;
using JourneySick.Business.Security;
using JourneySick.Data.IRepositories;
using JourneySick.Data.Models.DTOs.CommonDTO.Request;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;
using JourneySick.Data.Models.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RevenueSharingInvest.Business.Services.Extensions.Email;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JourneySick.Business.IServices.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly IUserDetailRepository _userDetailRepository;
        private readonly IUserInterestRepository _userInterestRepository;
        private readonly AppSecrect _appSecrect;
        private readonly ILogger<AuthenticateService> _logger;
        private readonly IMapper _mapper;

        public AuthenticateService(IUserService userService,
            IUserDetailRepository userDetailRepository,
            IUserRepository userRepository, 
            IUserInterestRepository userInterestRepository,
            IOptions<AppSecrect> appSecrect,
            ILogger<AuthenticateService> logger, IMapper mapper)
        {
            _userService = userService;
            _appSecrect = appSecrect.Value;
            _userRepository = userRepository;
            _userDetailRepository = userDetailRepository;
            _userInterestRepository = userInterestRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<LoginResponse> LoginWithSocial(string firebaseToken)
        {
            try
            {
                LoginResponse loginResponse = new();
                CurrentUserObject currentUser = await GetFirebaseToken(firebaseToken);
                UserVO userVO = await _userRepository.GetUserByEmail(currentUser.Email);
                
                if (userVO == null)
                {
                    userVO = new();
                    userVO.Avatar = currentUser.Avatar;
                    userVO.Email = currentUser.Email;
                    userVO.UserId = await GenerateUserID();
                    userVO.Username = await GenerateUserName();
                    userVO.Password = PasswordEncryption.Encrypt("Qwer1234!", _appSecrect.SecrectKey);
                    if (await _userRepository.CreateUser(userVO) > 0)
                    {
                        userVO.Role = UserRoleEnum.USER.ToString();
                        userVO.ActiveStatus = "INACTIVE";
                        userVO.Fullname = currentUser.Name;
                        userVO.Experience = 0;
                        userVO.TripCreated = 0;
                        userVO.TripJoined = 0;
                        userVO.TripCompleted = 0;
                        userVO.TripCancelled = 0;
                        userVO.CreateDate = DateTimePicker.GetDateTimeByTimeZone();
                        userVO.CreateBy = userVO.UserId;

                        if (await _userDetailRepository.CreateUserDetail(userVO) == 0)
                        {
                            throw new Exception();
                        }
                        loginResponse.Token = await GenerateTokenAsync(roleCheck: userVO.Role, userId: userVO.UserId, name: userVO.Fullname, avatar: userVO.Avatar);
                        currentUser.Name = userVO.Fullname;
                        currentUser.Role = userVO.Role;
                        currentUser.UserId = userVO.UserId;
                        loginResponse.CurrentUserObj = currentUser;
                    } else
                    {
                        throw new Exception();
                    }
                    

                }
                else
                {
                    UserRequest userRequest = _mapper.Map<UserRequest>(userVO);
                    loginResponse.Token = await GenerateTokenAsync(roleCheck: userVO.Role, userId: userVO.UserId, name: userVO.Fullname, avatar: userVO.Avatar);
                    currentUser.Name = userRequest.Fullname;
                    currentUser.Role = userRequest.Role;
                    currentUser.UserId = userRequest.UserId;
                    loginResponse.CurrentUserObj = currentUser;
                }

                return loginResponse;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public Task<LoginResponse> RegisterWithSocial(string firebaseToken)
        {
            throw new NotImplementedException();
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
                    throw new UserAlreadyExistException("This Username Already Used!!");
                }
                string checkEmailExist = await _userDetailRepository.GetEmailIfExist(registereRequest.Email);
                if (checkEmailExist != null)
                {
                    throw new UserAlreadyExistException("This Email Address Already Used!!");
                }
                string checkPhoneExist = await _userDetailRepository.GetPhoneIfExist(registereRequest.Phone);
                if (checkPhoneExist != null)
                {
                    throw new UserAlreadyExistException("This Phone Number Already Used!!");
                }

                userDetailEntity.UserId = await GenerateUserID();
                userDetailEntity.Username = registereRequest.Username;
                userDetailEntity.Password = PasswordEncryption.Encrypt(registereRequest.Password, _appSecrect.SecrectKey);
                userDetailEntity.SendDate = DateTimePicker.GetDateTimeByTimeZone();

                if (await _userRepository.CreateUser(userDetailEntity) > 0)
                {
                    userDetailEntity.Role = UserRoleEnum.USER.ToString();
                    userDetailEntity.Birthday = registereRequest.Birthday;
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
                        throw new RegisterUserException("Registration Failed!!");
                    }
                }
                registerResponse.Email = registereRequest.Email;
                registerResponse.FullName = userDetailEntity.Fullname;
                registerResponse.Username = registereRequest.Username;
                registerResponse.Token = await GenerateTokenAsync(UserRoleEnum.USER.ToString(), userDetailEntity.UserId, name: userDetailEntity.Fullname, userDetailEntity.Avatar);

                await EmailService.SendEmailRegister(userDetailEntity.Email, userDetailEntity.Fullname, await _userRepository.GetLastOneId());
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
                            if (userVO.Role.Equals(UserRoleEnum.USER.ToString()) && DateTime.Compare(userVO.SendDate.AddMinutes(30), DateTimePicker.GetDateTimeByTimeZone()) < 0)
                            {
                                await EmailService.SendEmailRegister(userVO.Email, userVO.Fullname, await _userRepository.GetLastOneId());
                                throw new LoginFailedException("Vui lòng xác thực email của bạn!!");
                            }
                        }
                        UserRequest userRequest = _mapper.Map<UserRequest>(userVO);
                        loginResponse.Token = await GenerateTokenAsync(roleCheck: userVO.Role, userId: userVO.UserId, name: userVO.Fullname, avatar: userVO.Avatar);
                        CurrentUserObject currentUser = new()
                        {
                            Name = userRequest.Fullname,
                            Role = userRequest.Role,
                            UserId = userRequest.UserId
                        };
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
                        if (userVO != null)
                        {
                            if (userVO.Role.Equals(UserRoleEnum.ADMIN.ToString()) || userVO.Role.Equals(UserRoleEnum.EMPL.ToString()))
                            {
                                UserRequest userRequest = _mapper.Map<UserRequest>(userVO);
                                loginResponse.Token = await GenerateTokenAsync(roleCheck: userVO.Role, userId: userVO.UserId, name: userVO.Fullname, avatar: userVO.Avatar);
                                CurrentUserObject currentUser = new();
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

        public async Task<UserRequest> GetCurrentInfo(CurrentUserObject currentUser)
        {
            try
            {
                UserVO userVO = await _userRepository.GetUserById(currentUser.UserId);
                // convert entity to dto
                UserRequest userRequest = _mapper.Map<UserRequest>(userVO);
                List<UserInterest> userInterests = await _userInterestRepository.GetAllUserInterests(currentUser.UserId);
                userRequest.userInterestList = userInterests;

                return userRequest;
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.StackTrace, ex);
                throw;
            }
        }

        private async Task<string> GenerateTokenAsync(string roleCheck, string userId, string name, string avatar)
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
                else if (roleCheck.Equals(UserRoleEnum.EMPL.ToString()))
                {
                    roleClaim = new Claim(ClaimTypes.Role, UserRoleEnum.EMPL.ToString());

                } else
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
                avatar ??= string.Empty;

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.SerialNumber, userId),
                        new Claim(ClaimTypes.Name, name),
                        roleClaim,
                        new Claim(ClaimTypes.Thumbprint, avatar)

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
        private async Task<string> GenerateUserName()
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
                    return "JourneySick" + newIdStr;
                }
                else
                {
                    return "JourneySick00000001";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }

        }

        private async Task<CurrentUserObject> GetFirebaseToken(string firebaseToken)
        {
            try
            {
                FirebaseToken decryptedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(firebaseToken);
                string uid = decryptedToken.Uid;
                UserRecord userRecord = await FirebaseAuth.DefaultInstance.GetUserAsync(uid);
                string email = userRecord.Email;
                string lastName = userRecord.DisplayName;
                string ImageUrl = userRecord.PhotoUrl.ToString();
                CurrentUserObject currentUser = new()
                {
                    Name = lastName,
                    Avatar = ImageUrl,
                    Email = email
                };
                return currentUser;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }
    }
}
