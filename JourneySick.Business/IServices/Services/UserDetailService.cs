using AutoMapper;
using JourneySick.Data.IRepositories;
using JourneySick.Data.IRepositories.Repositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.VO;

namespace JourneySick.Business.IServices.Services
{
    public class UserDetailService : IUserDetailService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserDetailRepository _userDetailRepository;
        private readonly IMapper _mapper;

        public UserDetailService(IUserDetailRepository userDetailRepository, IMapper mapper)
        {
            _userDetailRepository = userDetailRepository;
            _mapper = mapper;
        }

        public async Task<string> SelectAllUsersWithPaging()
        {
            throw new NotImplementedException();
        }

        public async Task<UserVO> SelectUserDetailByUserName(String username)
        {
            try {
                return await _userDetailRepository.SelectUserDetailByUserName(username);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

    }
}
