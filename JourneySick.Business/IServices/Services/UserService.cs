using AutoMapper;
using JourneySick.Data.IRepositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;

namespace JourneySick.Business.IServices.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<string> CreateUser(UserDTO userDTO)
        {
            try
            {
                userDTO.FldUserId = await GenerateUserID();
                Tbluser tblUser = _mapper.Map<Tbluser>(userDTO);
                int id = await _userRepository.CreateUser(tblUser);
                return userDTO.FldUserId;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<UserDTO> SelectUser(String userId)
        {
            return await _userRepository.SelectUser(userId);
        }

        private async Task<string> GenerateUserID()
        {
            string lastOne = await _userRepository.getLastOneId();
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

    }
}
