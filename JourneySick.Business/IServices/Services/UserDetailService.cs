using AutoMapper;
using JourneySick.Business.Models.DTOs;
using JourneySick.Data.IRepositories;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;
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

        public async Task<AllUserDTO> GetAllUsersWithPaging(int pageIndex, int pageSize, CurrentUserObj currentUser)
        {
            AllUserDTO result = new();
            try
            {
                List<TbluserVO> tblusers = await _userDetailRepository.GetAllUsersWithPaging(pageIndex, pageSize);
                // convert entity to dto
                List<UserVO> users = _mapper.Map<List<UserVO>>(tblusers);
                int count = await _userDetailRepository.CountAllUsers();
                result.listOfUser = users;
                result.numOfUser = count;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
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
