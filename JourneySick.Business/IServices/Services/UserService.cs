﻿using AutoMapper;
using JourneySick.Data.IRepositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.VO;

namespace JourneySick.Business.IServices.Services
{
    public class UserService : IUserService 
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserDetailRepository _userDetailRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IUserDetailRepository userDetailRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _userDetailRepository = userDetailRepository;
            _mapper = mapper;
        }

        public async Task<string> CreateUser(UserVO userVO)
        {
            try
            {
                // generate ID (format: USER00000000)
                userVO.FldUserId = await GenerateUserID();
                Tbluser tbluser = ConvertUserVOToTblUser(userVO);
                int id = await _userRepository.CreateUser(tbluser);
                Tbluserdetail tbluserdetail = ConvertUserVOToTblUserDetail(userVO);
                tbluserdetail.FldCreateBy = "Admin";
                tbluserdetail.FldCreateDate = DateTime.Now;
                await _userDetailRepository.CreateUserDetail(tbluserdetail);
                return userVO.FldUserId;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<UserDTO> GetUserById(String userId)
        {
            Tbluser tblUser = await _userRepository.GetUserById(userId);
            // convert entity to dto
            UserDTO userDTO = _mapper.Map<UserDTO>(tblUser);
            return userDTO;
        }

        public async Task<string> UpdateUser(UserVO userDTO)
        {
            try
            {
                // convert entity to dto
                Tbluser tblUser = _mapper.Map<Tbluser>(userDTO);
                return userDTO.FldUserId;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        private async Task<string> GenerateUserID()
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
                return "USER" + newIdStr;
            }
            else
            {
                return "USER00000001";
            }
        }

        private Tbluser ConvertUserVOToTblUser(UserVO userVO)
        {
            UserDTO userDTO = new()
            {
                FldUserId = userVO.FldUserId,
                FldUsername = userVO.FldUsername,
                FldPassword = userVO.FldPassword
            };

            Tbluser tbluser = _mapper.Map<Tbluser>(userDTO);
            return tbluser;
        }

        private Tbluserdetail ConvertUserVOToTblUserDetail(UserVO userVO)
        {
            UserDetailDTO userDetailDTO = new()
            {
                FldUserId = userVO.FldUserId,
                FldFullname = userVO.FldFullname,
                FldAddress = userVO.FldAddress,
                FldRole = userVO.FldRole,
                FldPhone = userVO.FldPhone,
                FldEmail = userVO.FldEmail,
                FldBirthday = userVO.FldBirthday
            };

            Tbluserdetail tbluserDetail = _mapper.Map<Tbluserdetail>(userDetailDTO);
            return tbluserDetail;
        }
    }
}
