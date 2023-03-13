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
    [Route("api/v1.0/tripRoles")]
    [EnableCors]
    public class TripRoleController : ControllerBase
    {
        private readonly ITripRoleService _tripRoleService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        private readonly IUserDetailService _userDetailService;
        public TripRoleController(ITripRoleService tripRoleService, IHttpContextAccessor httpContextAccessor)
        {
            _tripRoleService = tripRoleService;
            _httpContextAccessor = httpContextAccessor;
        }

        //CREATE
        [HttpPost]
        public async Task<IActionResult> CreateTripRole([FromBody] TripRoleDTO tripRoleDTO)
        {
            var result = await _tripRoleService.CreateTripRole(tripRoleDTO);
            return Ok(result);

        }

        //UPDATE
        [HttpPut]
        public async Task<IActionResult> UpdateTripRole([FromBody] TripRoleDTO tripRoleDTO)
        {
            var result = await _tripRoleService.CreateTripRole(tripRoleDTO);
            return Ok(result);

        }

        //GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAllTripRolesWithPaging(int pageIndex, int pageSize)
        {
            var result = new List<TripRoleDTO>();
            UserDetailDTO currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext, _userService, _userDetailService);
            result = await _tripRoleService.GetAllTripRolesWithPaging(pageIndex, pageSize, currentUser);
            return Ok(result);


        }

    }
}
