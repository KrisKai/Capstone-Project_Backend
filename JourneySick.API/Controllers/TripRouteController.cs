using JourneySick.Business.IServices;
using JourneySick.Data.Models.DTOs;
using JourneySick.API.Extensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using Microsoft.AspNetCore.Authorization;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;
using JourneySick.Data.Models.DTOs.CommonDTO.Request;

namespace JourneySick.API.Controllers
{
    [ApiController]
    [Route("api/v1.0/tripRoutes")]
    [EnableCors]
    public class TripRouteController : ControllerBase
    {
        private readonly ITripRouteService _tripRouteService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TripRouteController(ITripRouteService tripRouteService, IHttpContextAccessor httpContextAccessor)
        {
            _tripRouteService = tripRouteService;
            _httpContextAccessor = httpContextAccessor;
        }

        //GET ALL
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllTripRoutesWithPaging(int pageIndex, int pageSize, string? routeId)
        {
            var result = new AllTripRouteDTO();
            CurrentUserRequest currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            result = await _tripRouteService.GetAllTripRoutesWithPaging(pageIndex, pageSize, routeId);
            return Ok(result);

        }
        //GET
        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> GetTripRouteById([FromRoute] int id)
        {
            TripRouteDTO result = await _tripRouteService.GetTripRouteById(id);
            return Ok(result);

        }


        //CREATE
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateTripRoute([FromBody] TripRouteRequest tripRouteDTO)
        {
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = await _tripRouteService.CreateTripRoute(tripRouteDTO, currentUser);
            return Ok(result);

        }

        //UPDATE
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateTripRoute([FromBody] TripRouteRequest tripRouteDTO)
        {
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = await _tripRouteService.UpdateTripRoute(tripRouteDTO, currentUser);
            return Ok(result);

        }

        //DELETE BY ID
        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteTripRoute([FromRoute] int id)
        {
            var result = await _tripRouteService.DeleteTripRoute(id);
            return Ok(result);
        }
    }
}
