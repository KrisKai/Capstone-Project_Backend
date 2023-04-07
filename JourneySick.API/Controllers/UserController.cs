using JourneySick.Business.IServices;
using JourneySick.Data.Models.DTOs;
using JourneySick.API.Extensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using JourneySick.Business.Models.DTOs;
using JourneySick.Data.Models.VO;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
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
            var result = await _userService.UpdateUser(userVO);
            return Ok(result);

        }

        //GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAllUsersWithPaging(int pageIndex, int pageSize)
        {
            var result = new AllUserDTO();
            CurrentUserObj currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            result = await _userDetailService.GetAllUsersWithPaging(pageIndex, pageSize, currentUser);
            return Ok(result);

        }
        //GET
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] string id)
        {
            var result = await _userService.GetUserById(id);
            return Ok(result);
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
