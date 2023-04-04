﻿using JourneySick.Business.IServices;
using JourneySick.Data.Models.DTOs;
using JourneySick.API.Extensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

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

        //GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAllTripPlansWithPaging(int pageIndex, int pageSize)
        {
            var result = new List<TripPlanDTO>();
            UserDetailDTO currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext, _userService, _userDetailService);
            result = await _tripPlanService.GetAllTripPlansWithPaging(pageIndex, pageSize, currentUser);
            return Ok(result);

        }
        //GET
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTripPlanById([FromRoute]int id)
        {
            TripPlanDTO result = await _tripPlanService.GetTripPlanById(id);
            return Ok(result);

        }


        //CREATE
        [HttpPost]
        public async Task<IActionResult> CreateTripPlan([FromBody]TripPlanDTO tripPlanDTO)
        {
            var result = await _tripPlanService.CreateTripPlan(tripPlanDTO);
            return Ok(result);

        }

        //UPDATE
        [HttpPut]
        public async Task<IActionResult> UpdateTripPlan([FromBody] TripPlanDTO tripPlanDTO)
        {
            var result = await _tripPlanService.UpdateTripPlan(tripPlanDTO);
            return Ok(result);

        }

        //DELETE BY ID
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTripPlan([FromRoute]int id)
        {
            var result = await _tripPlanService.DeleteTripPlan(id);
            return Ok(result);
        }
    }
}