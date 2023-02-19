using AutoMapper;
using JourneySick.Business.Helpers.Exceptions;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Business.Services.ImplServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository= userRepository;
            _mapper= mapper;
        }
        public async Task<int> CreateUser(UserDTO userDTO)
        {
            try
            {
                Tbluser userEntity = _mapper.Map<Tbluser>(userDTO);
                Console.Write(userEntity.FldUsername);
                
                int result = await _userRepository.CreateUser(userEntity);
                return result;
            }catch(UserException ex)
            {
                throw new UserException("warning");
            }

        }
        public async Task<List<UserDTO>> SelectUser(UserDTO userDTO)
        {
            try
            {
                Tbluser userEntity = _mapper.Map<Tbluser>(userDTO);
                Console.Write(userEntity.FldUsername);
                
                List<Tbluser> result = await _userRepository.SelectUser(userEntity);
                List<UserDTO> finalResult = _mapper.Map<List<UserDTO>>(result);
                return finalResult;
            }catch(UserException ex)
            {
                throw new UserException("warning");
            }

        }

    }
}
