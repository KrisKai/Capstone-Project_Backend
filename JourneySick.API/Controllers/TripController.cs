using JourneySick.Business.IServices;
using JourneySick.Data.Models.DTOs;
using JourneySick.API.Extensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Business.Models.DTOs;
using JourneySick.Data.Models.Enums;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;
using JourneySick.Data.Models.DTOs.CommonDTO.GetOneDTO;
using Microsoft.AspNetCore.Authorization;

namespace JourneySick.API.Controllers
{
    [ApiController]
    [Route("api/v1.0/trips")]
    [EnableCors]
    public class TripController : ControllerBase
    {
        private readonly ITripService _tripService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TripController(ITripService tripService, IHttpContextAccessor httpContextAccessor)
        {
            _tripService = tripService;
            _httpContextAccessor = httpContextAccessor;
        }

        //CREATE
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateTrip([FromBody] TripVO tripVO)
        {
            var result = await _tripService.CreateTrip(tripVO);
            return Ok(result);

        }

        //UPDATE
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateTrip([FromBody] TripVO tripVO)
        {
            var result = await _tripService.UpdateTrip(tripVO);
            return Ok(result);

        }

        //GET ALL
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllTripsWithPaging(int pageIndex, int pageSize, string? tripName)
        {
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = new AllTripDTO();
            //if(currentUser.Role.Equals(UserRoleEnum.ADMIN.ToString()))
            //{
            result = await _tripService.GetAllTripsWithPaging(pageIndex, pageSize, tripName, currentUser);
            
            return Ok(result);
            //}
            //else
            //{
            //throw new Exception("d");
            //}

        }

        //GET
        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> GetTripById([FromRoute] string id)
        {
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            TripVO result = await _tripService.GetTripById(id);
            TripResponse tripResponse = new TripResponse();
            tripResponse.TripVO = result;
            tripResponse.CurrentUserObj = currentUser;
            return Ok(tripResponse);

        }

        //DELETE BY ID
        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteTrip(string id)
        {
            var result = await _tripService.DeleteTrip(id);
            return Ok(result);
        }

    }
}
