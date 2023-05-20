using JourneySick.Business.IServices;
using JourneySick.Data.Models.DTOs;
using JourneySick.API.Extensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using JourneySick.Data.Models.DTOs.CommonDTO.Request;

namespace JourneySick.API.Controllers
{
    [ApiController]
    [Route("api/v1.0/planLocations")]
    [EnableCors]
    public class PlanLocationController : ControllerBase
    {
        private readonly IPlanLocationService _planLocationService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        public PlanLocationController(IPlanLocationService planLocationService, IHttpContextAccessor httpContextAccessor)
        {
            _planLocationService = planLocationService;
            _httpContextAccessor = httpContextAccessor;
        }

        //GET ALL
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllLocationsWithPaging(int pageIndex, int pageSize)
        {
            var result = new List<PlanLocationDTO>();
            CurrentUserRequest currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            result = await _planLocationService.GetAllLocationsWithPaging(pageIndex, pageSize);
            return Ok(result);

        }

        //GET
        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> GetPlanLocationById([FromRoute] int id)
        {
            PlanLocationDTO result = await _planLocationService.GetPlanLocationById(id);
            return Ok(result);

        }


        //CREATE
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePlanLocation([FromBody] PlanLocationDTO planLocationDTO)
        {
            var result = await _planLocationService.CreatePlanLocation(planLocationDTO);
            return Ok(result);

        }

        //UPDATE
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdatePlanLocation([FromBody] PlanLocationDTO planLocationDTO)
        {
            var result = await _planLocationService.UpdatePlanLocation(planLocationDTO);
            return Ok(result);

        }

        //DELETE BY ID
        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            CurrentUserRequest currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);

            var result = await _planLocationService.DeletePlanLocation(id);
            return Ok(result);
        }

    }
}
