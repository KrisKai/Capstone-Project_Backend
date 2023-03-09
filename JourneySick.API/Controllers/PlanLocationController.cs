using JourneySick.Business.IServices;
using JourneySick.Data.Models.DTOs;
using JourneySick.API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using JourneySick.Business.IServices.Services;

namespace JourneySick.API.Controllers
{
    [ApiController]
    [Route("api/v1.0/plans")]
    [EnableCors]
    public class PlanLocationController : ControllerBase
    {
        private readonly IPlanLocationService _planLocationService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        private readonly IUserDetailService _userDetailService;
        public PlanLocationController(IPlanLocationService planLocationService, IHttpContextAccessor httpContextAccessor)
        {
            _planLocationService = planLocationService;
            _httpContextAccessor = httpContextAccessor;
        }

        //CREATE
        [HttpPost]
        public async Task<IActionResult> CreatePlanLocation([FromBody] PlanLocationDTO planLocationDTO)
        {
            var result = await _planLocationService.CreatePlanLocation(planLocationDTO);
            return Ok(result);
            
        }

        //UPDATE
        [HttpPost]
        public async Task<IActionResult> UpdatelanLocation([FromBody] PlanLocationDTO planLocationDTO)
        {
            var result = await _planLocationService.UpdatePlanLocation(planLocationDTO);
            return Ok(result);
            
        }

        //GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAllLocationsWithPaging(int pageIndex, int pageSize)
        {
            var result = new List<PlanLocationDTO>();
            UserDetailDTO currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext, _userService, _userDetailService);
            result = await _planLocationService.GetAllLocationsWithPaging(pageIndex, pageSize, currentUser);
            return Ok(result);


        }



    }
}
