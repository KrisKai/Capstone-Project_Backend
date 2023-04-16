using JourneySick.Business.IServices;
using JourneySick.Data.Models.DTOs;
using JourneySick.API.Extensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using JourneySick.Business.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Business.IServices.Services;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;

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
        public async Task<IActionResult> CreateUser([FromBody] UserVO userVO)
        {
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = await _userService.CreateUser(userVO, currentUser);
            return Ok(result);

        }

        //UPDATE
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateUser([FromBody] UserVO userVO)
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
            CurrentUserObj currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            result = await _userService.GetAllUsersWithPaging(pageIndex, pageSize, userName, currentUser);
            return Ok(result);

        }
        //GET
        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> GetUserById([FromRoute] string id)
        {
            CurrentUserObj currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
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
        public async Task<IActionResult> ChangePassword(string? fldUserId, string? fldOldPassword, string? fldPassword)
        {
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = await _userService.ChangePassword(fldUserId, fldOldPassword, fldPassword);
            return Ok(result);

        }
    }
}
