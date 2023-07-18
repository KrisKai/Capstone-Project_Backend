using JourneySick.Business.IServices;
using JourneySick.Data.Models.DTOs;
using JourneySick.API.Extensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.Request;

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
        public async Task<IActionResult> GetAllTripMembersWithPaging(int pageIndex, int pageSize, string tripId, string? memberName)
        {
            CurrentUserObject currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = await _tripMemberService.GetAllTripMembersWithPaging(pageIndex, pageSize, tripId, memberName);
            return Ok(result);

        }

        //GET ALL
        [HttpGet]
        [Route("get-all-by-email-or-username")]
        [Authorize]
        public async Task<IActionResult> GetAllTripMemberByEmailOrUsername(string value)
        {
            var result = await _tripMemberService.GetAllTripMemberByEmailOrUsername(value);
            return Ok(result);

        }

        //GET ALL
        [HttpGet]
        [Route("get-all-user")]
        [Authorize]
        public async Task<IActionResult> GetAllTripMemberUser(string tripId)
        {
            CurrentUserObject currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = await _tripMemberService.GetAllTripMemberUser(tripId, currentUser);
            return Ok(result);

        }

        //GET
        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> GetTripMemberById([FromRoute] int id)
        {
            TripMemberRequest result = await _tripMemberService.GetTripMemberById(id);
            return Ok(result);
        }


        //CREATE
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateTripMember([FromBody] TripMemberDTO tripMemberDTO)
        {
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = await _tripMemberService.CreateTripMember(tripMemberDTO, currentUser);
            return Ok(result);

        }

        //UPDATE
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateTripMember([FromBody] TripMemberDTO tripMemberDTO)
        {
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = await _tripMemberService.UpdateTripMember(tripMemberDTO, currentUser);
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

        //CONFIRM TRIP
        [AllowAnonymous]
        [HttpPut]
        [Route("confirm-trip")]
        public async Task<IActionResult> ConfirmTrip([FromBody] int id)
        {
            var result = await _tripMemberService.ConfirmTrip(id);
            return Ok(result);
        }

        //SEND MAIL
        [AllowAnonymous]
        [HttpPut]
        [Route("send-mail")]
        public async Task<IActionResult> SendMail([FromBody] int id)
        {
            var result = await _tripMemberService.SendMail(id);
            return Ok(result);
        }

        //SEND MAIL
        [AllowAnonymous]
        [HttpPut]
        [Route("send-mail-user")]
        public async Task<IActionResult> SendMailUser([FromBody] TripMemberRequest tripMemberRequest)
        {
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = await _tripMemberService.SendMailUser(tripMemberRequest.Email, tripMemberRequest.TripId, currentUser);
            return Ok(result);
        }
    }
}
