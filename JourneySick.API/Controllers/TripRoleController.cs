using JourneySick.Business.IServices;
using JourneySick.Data.Models.DTOs;
using JourneySick.API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using JourneySick.Business.IServices.Services;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.Request;

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

        //GET ALL
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllTripRolesWithPaging(int pageIndex, int pageSize, string? roleName)
        {
            var result = new AllTripRoleDTO();
            CurrentUserObject currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            result = await _tripRoleService.GetAllTripRolesWithPaging(pageIndex, pageSize, roleName);
            return Ok(result);


        }

        //GET
        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> GetTripRoleById([FromRoute] int id)
        {
            TripRoleDTO result = await _tripRoleService.GetTripRoleById(id);
            return Ok(result);

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
            var result = await _tripRoleService.UpdateTripRole(tripRoleDTO);
            return Ok(result);

        }

        //DELETE BY ID
        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteTripRole([FromRoute] int id)
        {
            var result = await _tripRoleService.DeleteTripRole(id);
            return Ok(result);
        }

    }
}
