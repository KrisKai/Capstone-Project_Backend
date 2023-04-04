using JourneySick.Business.IServices;
using JourneySick.Data.Models.DTOs;
using JourneySick.API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using JourneySick.Business.IServices.Services;
using JourneySick.Business.Models.DTOs;

namespace JourneySick.API.Controllers
{
    [ApiController]
    [Route("api/v1.0/tripDetails")]
    [EnableCors]
    public class TripDetailController : ControllerBase
    {
        private readonly ITripDetailService _tripDetailService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        private readonly IUserDetailService _userDetailService;
        public TripDetailController(ITripDetailService tripDetailService, IHttpContextAccessor httpContextAccessor)
        {
            _tripDetailService = tripDetailService;
            _httpContextAccessor = httpContextAccessor;
        }

        //GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAllTripDetailsWithPaging(int pageIndex, int pageSize)
        {
            var result = new List<TripDetailDTO>();
            CurrentUserObj currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            result = await _tripDetailService.GetAllTripDetailsWithPaging(pageIndex, pageSize, currentUser);
            return Ok(result);

        }

        //GET
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTripDetailById([FromRoute] string id)
        {
            TripDetailDTO result = await _tripDetailService.GetTripDetailById(id);
            return Ok(result);

        }

        //CREATE
        [HttpPost]
        public async Task<IActionResult> CreateTripDetail([FromBody] TripDetailDTO tripDetailDTO)
        {
            var result = await _tripDetailService.CreateTripDetail(tripDetailDTO);
            return Ok(result);

        }

        //UPDATE
        [HttpPut]
        public async Task<IActionResult> UpdateTripDetail([FromBody] TripDetailDTO tripDetailDTO)
        {
            var result = await _tripDetailService.UpdateTripDetail(tripDetailDTO);
            return Ok(result);

        }

        //DELETE BY ID
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTripDetail([FromRoute] string id)
        {
            var result = await _tripDetailService.DeleteTripDetail(id);
            return Ok(result);
        }
    }
}
