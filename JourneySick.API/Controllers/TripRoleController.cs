﻿using JourneySick.Business.IServices;
using JourneySick.Data.Models.DTOs;
using JourneySick.API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using JourneySick.Business.IServices.Services;
using JourneySick.Business.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;

namespace JourneySick.API.Controllers
{
    [ApiController]
    [Route("api/v1.0/tripRoles")]
    [EnableCors]
    public class TripRoleController : ControllerBase
    {
        private readonly ITripRoleService _tripRoleService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TripRoleController(ITripRoleService tripRoleService, IHttpContextAccessor httpContextAccessor)
        {
            _tripRoleService = tripRoleService;
            _httpContextAccessor = httpContextAccessor;
        }

        //CREATE
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateTripRole([FromBody] TripRoleDTO tripRoleDTO)
        {
            var result = await _tripRoleService.CreateTripRole(tripRoleDTO);
            return Ok(result);

        }

        //UPDATE
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateTripRole([FromBody] TripRoleDTO tripRoleDTO)
        {
            var result = await _tripRoleService.CreateTripRole(tripRoleDTO);
            return Ok(result);

        }

        //GET ALL
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllTripRolesWithPaging(int pageIndex, int pageSize, string? roleName)
        {
            var result = new AllTripRoleDTO();
            CurrentUserObj currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            result = await _tripRoleService.GetAllTripRolesWithPaging(pageIndex, pageSize, roleName);
            return Ok(result);


        }

    }
}
