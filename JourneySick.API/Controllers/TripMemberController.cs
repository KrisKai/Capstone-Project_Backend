using JourneySick.Business.IServices;
using JourneySick.Data.Models.DTOs;
using JourneySick.API.Extensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using JourneySick.Business.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;

namespace JourneySick.API.Controllers
{
    [ApiController]
    [Route("api/v1.0/tripMembers")]
    [EnableCors]
    public class TripMemberController : ControllerBase
    {
        private readonly ITripMemberService _tripMemberService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        public TripMemberController(ITripMemberService tripMemberService, IHttpContextAccessor httpContextAccessor)
        {
            _tripMemberService = tripMemberService;
            _httpContextAccessor = httpContextAccessor;
        }

        //GET ALL
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllTripMembersWithPaging(int pageIndex, int pageSize, string? memberName)
        {
            var result = new AllTripMemberDTO();
            CurrentUserObj currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            result = await _tripMemberService.GetAllTripMembersWithPaging(pageIndex, pageSize, memberName);
            return Ok(result);

        }
        //GET
        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> GetTripMemberById([FromRoute] int id)
        {
            TripMemberDTO result = await _tripMemberService.GetTripMemberById(id);
            return Ok(result);

        }


        //CREATE
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateTripMember([FromBody] TripMemberDTO tripMemberDTO)
        {
            var result = await _tripMemberService.CreateTripMember(tripMemberDTO);
            return Ok(result);

        }

        //UPDATE
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateTripMember([FromBody] TripMemberDTO tripMemberDTO)
        {
            var result = await _tripMemberService.UpdateTripMember(tripMemberDTO);
            return Ok(result);

        }

        //DELETE BY ID
        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteTripMember([FromRoute] int id)
        {
            var result = await _tripMemberService.DeleteTripMember(id);
            return Ok(result);
        }
    }
}
