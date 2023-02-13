using AutoMapper;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Business.Helpers
{

    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<UserDTO, Tbluser>()
                .ForMember(des => des.FldUserId, act => act.MapFrom(src => src.UserId))
                .ForMember(des => des.FldUsername, act => act.MapFrom(src => src.UserName))
                .ForMember(des => des.FldPassword, act => act.MapFrom(src => src.Password))
                .ReverseMap(); //reverse so the both direction
        }
    }
}
