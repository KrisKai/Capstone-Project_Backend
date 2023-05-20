using JourneySick.Business.IServices;
using JourneySick.Data.Models.DTOs;
using JourneySick.API.Extensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using Microsoft.AspNetCore.Authorization;
using JourneySick.Data.Models.DTOs.CommonDTO.Request;

namespace JourneySick.API.Controllers
{
    [ApiController]
    [Route("api/v1.0/tripItems")]
    [EnableCors]
    public class TripItemController : ControllerBase
    {
        private readonly ITripItemService _tripItemService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TripItemController(ITripItemService tripItemService, IHttpContextAccessor httpContextAccessor)
        {
            _tripItemService = tripItemService;
            _httpContextAccessor = httpContextAccessor;
        }

        //GET ALL
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllTripItemsWithPaging(int pageIndex, int pageSize, string? itemId, int categoryId)
        {
            var result = new AllTripItemDTO();
            CurrentUserRequest currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            result = await _tripItemService.GetAllTripItemsWithPaging(pageIndex, pageSize, itemId, categoryId);
            return Ok(result);

        }
        //GET
        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> GetTripItemById([FromRoute] int id)
        {
            TripItemDTO result = await _tripItemService.GetTripItemById(id);
            return Ok(result);

        }


        //CREATE
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateTripItem([FromBody] TripItemDTO tripItemDTO)
        {
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = await _tripItemService.CreateTripItem(tripItemDTO, currentUser);
            return Ok(result);

        }

        //UPDATE
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateTripItem([FromBody] TripItemDTO tripItemDTO)
        {
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = await _tripItemService.UpdateTripItem(tripItemDTO, currentUser);
            return Ok(result);

        }

        //DELETE BY ID
        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteTripItem([FromRoute] int id)
        {
            var result = await _tripItemService.DeleteTripItem(id);
            return Ok(result);
        }
    }
}
