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
using JourneySick.Data.Models.DTOs.CommonDTO.GetOneDTO;

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
        [Route("create-admin")]
        public async Task<IActionResult> CreateAdmin([FromBody] UserVO userVO)
        {
            var result = await _userService.CreateAdmin(userVO);
            return Ok(result);

        }

        //UPDATE
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserVO userVO)
        {
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = await _userService.UpdateUser(userVO);
            return Ok(result);

        }

        //GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAllUsersWithPaging(int pageIndex, int pageSize)
        {
            var result = new AllUserDTO();
            CurrentUserObj currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            result = await _userService.GetAllUsersWithPaging(pageIndex, pageSize, currentUser);
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
            UserResponse userResponse = new();
            userResponse.UserVO = result;
            userResponse.UserId = currentUser.UserId;
            userResponse.Role = currentUser.Role;
            return Ok(userResponse);
        }


        //DELETE BY ID
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _userService.DeleteUser(id);
            return Ok(result);
        }
    }
}
