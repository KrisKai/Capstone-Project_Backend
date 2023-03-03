using AutoMapper;
using JourneySick.Data.IRepositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.VO;

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
                // generate ID (format: USER00000000)
                userDTO.FldUserId = await GenerateUserID();
                // convert entity to dto
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
            Tbluser tblUser = await _userRepository.SelectUser(userId);
            // convert entity to dto
            UserDTO userDTO = _mapper.Map<UserDTO>(tblUser);
            return userDTO;
        }

        private async Task<string> GenerateUserID()
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

    }
}
