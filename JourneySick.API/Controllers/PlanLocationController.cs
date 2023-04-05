﻿using JourneySick.Business.IServices;
using JourneySick.Data.Models.DTOs;
using JourneySick.API.Extensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using JourneySick.Business.Models.DTOs;

namespace JourneySick.API.Controllers
{
    [ApiController]
    [Route("api/v1.0/planLocations")]
    [EnableCors]
    public class PlanLocationController : ControllerBase
    {
        private readonly IPlanLocationService _planLocationService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        private readonly IUserDetailService _userDetailService;
        public PlanLocationController(IPlanLocationService planLocationService, IHttpContextAccessor httpContextAccessor)
        {
            _planLocationService = planLocationService;
            _httpContextAccessor = httpContextAccessor;
        }

        //GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAllLocationsWithPaging(int pageIndex, int pageSize)
        {
            var result = new List<PlanLocationDTO>();
            CurrentUserObj currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            result = await _planLocationService.GetAllLocationsWithPaging(pageIndex, pageSize, currentUser);
            return Ok(result);

        }

        //GET
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPlanLocationById([FromRoute] int id)
        {
            PlanLocationDTO result = await _planLocationService.GetPlanLocationById(id);
            return Ok(result);

        }


        //CREATE
        [HttpPost]
        public async Task<IActionResult> CreatePlanLocation([FromBody] PlanLocationDTO planLocationDTO)
        {
            var result = await _planLocationService.CreatePlanLocation(planLocationDTO);
            return Ok(result);

        }

        //UPDATE
        [HttpPut]
        public async Task<IActionResult> UpdatePlanLocation([FromBody] PlanLocationDTO planLocationDTO)
        {
            var result = await _planLocationService.UpdatePlanLocation(planLocationDTO);
            return Ok(result);

        }

        //DELETE BY ID
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            CurrentUserObj currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);

            var result = await _planLocationService.DeletePlanLocation(id);
            return Ok(result);
        }

    }
}
