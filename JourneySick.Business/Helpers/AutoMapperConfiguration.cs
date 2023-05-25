using AutoMapper;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.Request;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;

namespace JourneySick.Business.Helpers
{

    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<UserDTO, User>()
                .ReverseMap(); //reverse so the both direction{
            CreateMap<TripPlanDTO, TripPlan>()
                .ReverseMap(); //reverse so the both direction
            CreateMap<TripMemberDTO, TripMember>()
                .ReverseMap(); //reverse so the both direction
            CreateMap<TripRoleDTO, TripRole>()
                .ReverseMap(); //reverse so the both direction
            CreateMap<TripItemDTO, TripItem>()
                .ReverseMap(); //reverse so the both direction
            CreateMap<TripDTO, Trip>()
                .ReverseMap(); //reverse so the both direction
            CreateMap<CreateTripRequest, TripVO>()
                .ReverseMap(); //reverse so the both direction
            CreateMap<TripDetailDTO, TripDetail>()
                .ReverseMap(); //reverse so the both direction
            CreateMap<UserDetailDTO, UserDetail>()
                .ReverseMap(); //reverse so the both direction
            CreateMap<PlanLocationDTO, PlanLocation>()
                .ReverseMap(); //reverse so the both direction
            CreateMap<UserRequest, UserVO>()
                .ReverseMap(); //reverse so the both direction
            CreateMap<TripRequest, TripVO>()
                .ReverseMap(); //reverse so the both direction
            CreateMap<TripMemberRequest, TripmemberVO>()
                .ReverseMap(); //reverse so the both direction
            CreateMap<FeedbackRequest, FeedbackVO>()
                .ReverseMap(); //reverse so the both direction
            CreateMap<CreateFeedbackRequest, FeedbackVO>()
                .ReverseMap(); //reverse so the both direction
            CreateMap<UpdateFeedbackRequest, FeedbackVO>()
                .ReverseMap(); //reverse so the both direction
            CreateMap<ItemDTO, Item>()
                .ReverseMap(); //reverse so the both direction
            CreateMap<CreateItemRequest, Item>()
                .ReverseMap(); //reverse so the both direction
            CreateMap<UpdateItemRequest, Item>()
                .ReverseMap(); //reverse so the both direction
            CreateMap<ItemCategoryDTO, ItemCategory>()
                .ReverseMap(); //reverse so the both direction
            CreateMap<CreateItemCategoryRequest, ItemCategory>()
                .ReverseMap(); //reverse so the both direction
            CreateMap<UpdateItemCategoryRequest, ItemCategory>()
                .ReverseMap(); //reverse so the both direction
            CreateMap<ItemRequest, ItemVO>()
                .ReverseMap(); //reverse so the both direction
            CreateMap<MapLocationDTO, MapLocation>()
                .ReverseMap(); //reverse so the both direction
            CreateMap<TripRouteRequest, TriprouteVO>()
                .ReverseMap(); //reverse so the both direction
            CreateMap<TripRouteDTO, TripRoute>()
                .ReverseMap(); //reverse so the both direction
            CreateMap<RoutePlanDTO, RoutePlan>()
                .ReverseMap(); //reverse so the both direction
        }
    }
}
