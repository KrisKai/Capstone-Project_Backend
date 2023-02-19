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
                .ReverseMap(); //reverse so the both direction{
            CreateMap<TripPlanDTO, Tbltripplan>()
                .ReverseMap(); //reverse so the both direction
            CreateMap<TripMemberDTO, Tbltripmember>()
                .ReverseMap(); //reverse so the both direction
            CreateMap<TripRoleDTO, Tbltriprole>()
                .ReverseMap(); //reverse so the both direction
            CreateMap<TripDTO, Tbltrip>()
                .ReverseMap(); //reverse so the both direction
            CreateMap<TripDetailDTO, Tbltripdetail>()
                .ReverseMap(); //reverse so the both direction
            CreateMap<UserDetailDTO, Tbluserdetail>()
                .ReverseMap(); //reverse so the both direction
            CreateMap<PlanLocationDTO, Tblplanlocation>()
                .ReverseMap(); //reverse so the both direction
        }
    }
}
