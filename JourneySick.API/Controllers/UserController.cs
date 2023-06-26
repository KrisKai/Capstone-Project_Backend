using JourneySick.Business.IServices;
using JourneySick.API.Extensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using Microsoft.AspNetCore.Authorization;
using JourneySick.Data.Models.DTOs.CommonDTO.Request;

namespace JourneySick.API.Controllers
{
    [ApiController]
    [Route("api/v1.0/users")]
    [EnableCors]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserController(IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        //CREATE
        [HttpPost]
        //[Route("create-admin")]
        [Authorize]
        public async Task<IActionResult> CreateUser([FromBody] UserRequest userVO)
        {
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = await _userService.CreateUser(userVO, currentUser);
            return Ok(result);

        }

        //UPDATE
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateUser([FromBody] UserRequest userVO)
        {
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = await _userService.UpdateUser(userVO, currentUser);
            return Ok(result);

        }

        //GET ALL
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllUsersWithPaging(int pageIndex, int pageSize, string? userName)
        {
            var result = new AllUserDTO();
            CurrentUserObject currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            result = await _userService.GetAllUsersWithPaging(pageIndex, pageSize, userName, currentUser);
            return Ok(result);

        }
        //GET
        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> GetUserById([FromRoute] string id)
        {
            var result = await _userService.GetUserById(id);
            return Ok(result);
        }


        //DELETE BY ID
        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _userService.DeleteUser(id);
            return Ok(result);
        }

        //RESET PASSWORD
        [HttpPut]
        [Route("reset-password")]
        [Authorize]
        public async Task<IActionResult> ResetPassword([FromBody] string? id)
        {
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = await _userService.ResetPassword(id, currentUser);
            return Ok(result);

        }

        //CHANGE PASSWORD
        [HttpPut]
        [Route("change-password")]
        [Authorize]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest changePasswordDTO)
        {
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = await _userService.ChangePassword(changePasswordDTO);
            return Ok(result);

        }

        //CHANGE STATUS
        [HttpPut]
        [Route("change-status")]
        [Authorize]
        public async Task<IActionResult> UpdateAcitveStatus(UserRequest userVO)
        {
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = await _userService.UpdateAcitveStatus(userVO, currentUser);
            return Ok(result);

        }

        //CONFIRM TRIP
        [AllowAnonymous]
        [HttpPut]
        [Route("confirm-user")]
        public async Task<IActionResult> ConfirmUser([FromBody] string id)
        {
            var result = await _userService.ConfirmUser(id);
            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        [Route("check-interest")]
        public async Task<IActionResult> CheckUserHavingInterest()
        {
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = await _userService.CheckUserHavingInterest(currentUser.UserId);
            return Ok(result);
        }

        //CREATE
        [HttpPost]
        [Route("create-user-interest")]
        [Authorize]
        public async Task<IActionResult> CreateUserInterest([FromBody] List<string> data)
        {
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = await _userService.CreateUserInterest(data, currentUser);
            return Ok(result);

        }

        //DELETE
        [HttpDelete]
        [Route("delete-interest-by-interest-id")]
        [Authorize]
        public async Task<IActionResult> DeleteUserInterest(int id)
        {
            var result = await _userService.DeleteUserInterestByInterestId(id);
            return Ok(result);

        }
    }
}
