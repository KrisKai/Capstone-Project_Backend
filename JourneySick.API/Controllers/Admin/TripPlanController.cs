using JourneySick.Business.IServices;
using JourneySick.Data.Models.DTOs;
using JourneySick.API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using JourneySick.Business.IServices.Services;

namespace JourneySick.API.Controllers.Admin
{
    [ApiController]
    [Route("api/v1.0/plans")]
    [EnableCors]
    public class TripPlanController : ControllerBase
    {
        private readonly ITripPlanService _tripPlanService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        private readonly IUserDetailService _userDetailService;
        public TripPlanController(ITripPlanService tripPlanService, IHttpContextAccessor httpContextAccessor)
        {
            _tripPlanService = tripPlanService;
            _httpContextAccessor = httpContextAccessor;
        }

        //CREATE
        [HttpPost]
        public async Task<IActionResult> CreateTripPlan([FromBody] TripPlanDTO tripPlanDTO)
        {
            var result = await _tripPlanService.CreateTripPlan(tripPlanDTO);
            return Ok(result);

        }

        //GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAllPlansWithPaging(int pageIndex, int pageSize)
        {
            var result = new List<TripPlanDTO>();
            UserDetailDTO currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext, _userService, _userDetailService);
            //result = await _tripPlanService.GetAllPlansWithPaging(pageIndex, pageSize, currentUser);
            return Ok(result);


        }



    }
}
