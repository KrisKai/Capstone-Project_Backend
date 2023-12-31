﻿using JourneySick.Business.IServices;
using JourneySick.API.Extensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using Microsoft.AspNetCore.Authorization;
using JourneySick.Data.Models.Entities.VO;
using JourneySick.Data.Models.DTOs.CommonDTO.Request;

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
        public async Task<IActionResult> CreateTrip([FromForm] CreateTripRequest tripRequest)
        {
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = await _tripService.CreateTrip(tripRequest, currentUser);
            return Ok(result);
        }

        //UPDATE
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateTrip([FromForm] UpdateTripRequest tripVO)
        {
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = await _tripService.UpdateTrip(tripVO, currentUser);
            return Ok(result);
        }

        //GET ALL
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllTripsWithPaging(int pageIndex, int pageSize, string? tripName)
        {
            AllTripDTO result = await _tripService.GetAllTripsWithPaging(pageIndex, pageSize, tripName);
            return Ok(result);

        }

        //GET
        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> GetTripById([FromRoute] string id)
        {
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            TripVO result = await _tripService.GetTripById(id, currentUser);
            return Ok(result);

        }

        //DELETE BY ID
        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteTrip(string id)
        {
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = await _tripService.DeleteTrip(id, currentUser);
            return Ok(result);
        }

        //TRIP STATISTIC
        [HttpGet]
        //[Authorize]
        [Route("trip-statistic")]
        public async Task<IActionResult> TripStatistic()
        {
            var result = await _tripService.TripStatistic();
            return Ok(result);

        }

        //TRIP STATISTIC
        [HttpGet]
        [Authorize]
        [Route("trip-history")]
        public async Task<IActionResult> TripHistory()
        {
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = await _tripService.GetTripHistory(currentUser.UserId);
            return Ok(result);

        }

        //TRIP STATISTIC
        [HttpPost]
        [Authorize]
        [Route("create-trip-user")]
        public async Task<IActionResult> CreateTripUser([FromForm] CreateTripRequest tripRequest)
        {
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = await _tripService.CreateTripUser(tripRequest, currentUser);
            return Ok(result);

        }

        //UPDATE
        [HttpPut]
        [Authorize]
        [Route("update-trip-thumbnail")]
        public async Task<IActionResult> UpdateTripThumbnail([FromForm] UpdateTripRequest tripVO)
        {
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = await _tripService.UpdateTripThumbnail(tripVO, currentUser);
            return Ok(result);
        }

    }
}
