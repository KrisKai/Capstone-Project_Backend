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
    [Route("api/v1.0/trips")]
    [EnableCors]
    public class TripController : ControllerBase
    {
        private readonly ITripService _tripService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        private readonly IUserDetailService _userDetailService;
        public TripController(ITripService tripService, IHttpContextAccessor httpContextAccessor)
        {
            _tripService = tripService;
            _httpContextAccessor = httpContextAccessor;
        }

        //CREATE
        [HttpPost]
        public async Task<IActionResult> CreateTrip([FromBody] TripDTO tripDTO)
        {
            var result = await _tripService.CreateTrip(tripDTO);
            return Ok(result);

        }

        //UPDATE
        [HttpPut]
        public async Task<IActionResult> UpdateTrip([FromBody] TripDTO tripDTO)
        {
            var result = await _tripService.UpdateTrip(tripDTO);
            return Ok(result);

        }

        //GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAllTripsWithPaging(int pageIndex, int pageSize)
        {
            var result = new List<UserDTO>();
            UserDetailDTO currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext, _userService, _userDetailService);
            result = await _tripService.GetAllTripsWithPaging(pageIndex, pageSize, currentUser);
            return Ok(result);

        }



    }
}
