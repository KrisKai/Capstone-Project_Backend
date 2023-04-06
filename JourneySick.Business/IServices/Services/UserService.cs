using AutoMapper;
using JourneySick.Data.IRepositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using Microsoft.Extensions.Logging;

namespace JourneySick.Business.IServices.Services
{
    public class UserService : IUserService 
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, IMapper mapper, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<string> CreateUser(UserDTO userDTO)
        {
            try
            {
                // generate ID (format: USER00000000)
                userDTO.FldUserId = await GenerateUserID();
                // convert entity to dto
                Tbluser tblUser = _mapper.Map<Tbluser>(userDTO);
                int id = await _userRepository.CreateUser(tblUser);
                return userDTO.FldUserId;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserDTO> GetUserById(String userId)
        {
            try
            {
                Tbluser tblUser = await _userRepository.GetUserById(userId);
                // convert entity to dto
                UserDTO userDTO = _mapper.Map<UserDTO>(tblUser);
                return userDTO;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw new Exception(ex.Message);
            }

        }

        public Task<string> UpdateUser(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        private async Task<string> GenerateUserID()
        {
            try
            {
                string lastOne = await _userRepository.GetLastOneId();
                if (lastOne != null)
                {
                    string lastId = lastOne.Substring(4);
                    int newId = Convert.ToInt32(lastId) + 1;
                    string newIdStr = Convert.ToString(newId);
                    while (newIdStr.Length < 8)
                    {
                        newIdStr = "0" + newIdStr;
                    }
                    return "USER" + newIdStr;
                }
                else
                {
                    return "USER00000001";
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw new Exception(ex.Message);
            }

        }

    }
}
