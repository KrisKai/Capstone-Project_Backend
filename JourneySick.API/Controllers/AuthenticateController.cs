using JourneySick.Business.IServices;
using JourneySick.Data.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using JourneySick.API.Extensions;

namespace JourneySick.API.Controllers
{
    [ApiController]
    [Route("api/v1.0/authenticate")]
    [EnableCors]
    public class AuthenticateController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthenticateService _authenticateService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthenticateController(IUserService userService, IHttpContextAccessor httpContextAccessor, IAuthenticateService authenticateService)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
            _authenticateService = authenticateService;
        }

        //CREATE
        [AllowAnonymous]
        [HttpPost]
        [Route("register-user")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterRequest registerRequest)
        {
            var result = await _authenticateService.RegisterUser(registerRequest);
            return Ok(result);
        }

        //LOGIN
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var result = await _authenticateService.Login(loginRequest);
            return Ok(result);
        }

        //LOGIN-USER
        [AllowAnonymous]
        [HttpPost]
        [Route("login-user")]
        public async Task<IActionResult> LoginUser([FromBody] LoginRequest loginRequest)
        {
            var result = await _authenticateService.LoginUser(loginRequest);
            return Ok(result);
        }

        [HttpGet]
        [Route("getCurrentUser")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            if(currentUser != null)
            {
                if ("EMPL".Equals(currentUser.Role))
                {
                    currentUser.Role = "Employee";
                }
                else
                {
                    currentUser.Role = "Admin";
                }
            }
            return Ok(currentUser);
        }

        [HttpGet]
        [Route("getCurrentInfo")]
        [Authorize]
        public async Task<IActionResult> GetCurrentInfo()
        {
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = await _authenticateService.GetCurrentInfo(currentUser);
            return Ok(result);
        }
    }
}
