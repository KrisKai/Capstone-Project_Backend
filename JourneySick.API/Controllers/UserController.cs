using JourneySick.Business.IServices;
using JourneySick.Data.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;

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
        public async Task<IActionResult> CreateArea([FromBody] UserDTO userDTO)
        {
            var result = await _userService.CreateUser(userDTO);
            return Ok(result);
            
        }

/*        //GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAllAreas(int pageIndex, int pageSize)
        {
            var result = new List<UserDTO>();
            result = await _areaService.GetAllAreas(pageIndex, pageSize, currentUser);
            return Ok(result);
            

        }*/

    }
}
