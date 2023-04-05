using AutoMapper;
using JourneySick.Business.Models.DTOs;
using JourneySick.Data.IRepositories;
using JourneySick.Data.IRepositories.Repositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;
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
                throw new Exception();
            }
        }

    }
}
