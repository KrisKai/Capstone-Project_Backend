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
    [Route("api/v1.0/users")]
    [EnableCors]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserDetailService _userDetailService;
        public UserController(IUserService userService, IHttpContextAccessor httpContextAccessor, IUserDetailService userDetailService)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
            _userDetailService = userDetailService;
        }

        //CREATE
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO userDTO)
        {
            var result = await _userService.CreateUser(userDTO);
            return Ok(result);

        }

        //UPDATE
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserDTO userDTO)
        {
            var result = await _userService.UpdateUser(userDTO);
            return Ok(result);

        }

        //GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAllUsersWithPaging(int pageIndex, int pageSize)
        {
            var result = new List<UserDTO>();
           // UserDetailDTO currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext, _userService, _userDetailService);
            //result = await _userService.GetAllUsersWithPaging(pageIndex, pageSize, currentUser);
            return Ok(result);


        }



    }
}
