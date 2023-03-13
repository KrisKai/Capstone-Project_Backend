using JourneySick.Business.IServices;
using JourneySick.Data.Models.DTOs;
using JourneySick.API.Extensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace JourneySick.API.Controllers.Admin
{
    [ApiController]
    [Route("api/v1.0/tripMembers")]
    [EnableCors]
    public class TripMemberController : ControllerBase
    {
        private readonly ITripMemberService _tripMemberService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        private readonly IUserDetailService _userDetailService;
        public TripMemberController(ITripMemberService tripMemberService, IHttpContextAccessor httpContextAccessor)
        {
            _tripMemberService = tripMemberService;
            _httpContextAccessor = httpContextAccessor;
        }

        //GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAllTripMembersWithPaging(int pageIndex, int pageSize)
        {
            var result = new List<TripMemberDTO>();
            UserDetailDTO currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext, _userService, _userDetailService);
            result = await _tripMemberService.GetAllTripMembersWithPaging(pageIndex, pageSize, currentUser);
            return Ok(result);

        }
        //GET
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTripMemberById([FromRoute] int id)
        {
            TripMemberDTO result = await _tripMemberService.GetTripMemberById(id);
            return Ok(result);

        }


        //CREATE
        [HttpPost]
        public async Task<IActionResult> CreateTripMember([FromBody] TripMemberDTO tripMemberDTO)
        {
            var result = await _tripMemberService.CreateTripMember(tripMemberDTO);
            return Ok(result);

        }

        //UPDATE
        [HttpPut]
        public async Task<IActionResult> UpdateTripMember([FromBody] TripMemberDTO tripMemberDTO)
        {
            var result = await _tripMemberService.UpdateTripMember(tripMemberDTO);
            return Ok(result);

        }

        //DELETE BY ID
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTripMember([FromRoute]int id)
        {
            var result = await _tripMemberService.DeleteTripMember(id);
            return Ok(result);
        }
    }
}
