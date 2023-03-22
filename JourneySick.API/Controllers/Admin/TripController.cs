using JourneySick.Business.IServices;
using JourneySick.Data.Models.DTOs;
using JourneySick.API.Extensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

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
            var result = new List<TripDTO>();
            UserDetailDTO currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext, _userService, _userDetailService);
            result = await _tripService.GetAllTripsWithPaging(pageIndex, pageSize, currentUser);
            return Ok(result);

        }


        //GET
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTripById([FromRoute] string id)
        {
            TripDTO result = await _tripService.GetTripById(id);
            return Ok(result);

        }

        //DELETE BY ID
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTrip(string id)
        {
            var result = await _tripService.DeleteTrip(id);
            return Ok(result);
        }

    }
}
