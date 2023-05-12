using JourneySick.Business.IServices;
using JourneySick.Data.Models.DTOs;
using JourneySick.API.Extensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Business.Models.DTOs;
using JourneySick.Data.Models.Enums;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;
using Microsoft.AspNetCore.Authorization;
using JourneySick.Data.Models.DTOs.CommonDTO;

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
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = await _tripService.CreateTrip(tripVO, currentUser);
            return Ok(result);

        }

        //UPDATE
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateTrip([FromBody] TripVO tripVO)
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
            var result = new AllTripDTO();
            result = await _tripService.GetAllTripsWithPaging(pageIndex, pageSize, tripName);
            return Ok(result);

        }

        //GET
        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> GetTripById([FromRoute] string id)
        {
            TripVO result = await _tripService.GetTripById(id);
            return Ok(result);

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

        //TRIP STATISTIC
        [HttpGet]
        [Authorize]
        [Route("trip-statistic")]
        public async Task<IActionResult> TripStatistic()
        {
            var result = new TripStatisticResponse();
            result = await _tripService.TripStatistic();
            return Ok(result);

        }

    }
}
