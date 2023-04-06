using AutoMapper;
using JourneySick.Data.IRepositories;
using JourneySick.Data.IRepositories.Repositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.VO;
using Microsoft.Extensions.Logging;

namespace JourneySick.Business.IServices.Services
{
    public class UserDetailService : IUserDetailService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserDetailRepository _userDetailRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserDetailService> _logger;

        public UserDetailService(IUserDetailRepository userDetailRepository, IMapper mapper, ILogger<UserDetailService> logger)
        {
            _userDetailRepository = userDetailRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<string> GetAllUsersWithPaging()
        {
            throw new NotImplementedException();
        }

        public async Task<UserVO> GetUserDetailByUserName(String username)
        {
            try {
                return await _userDetailRepository.GetUserDetailByUserName(username);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw new Exception(ex.Message);
            }
        }

    }
}
