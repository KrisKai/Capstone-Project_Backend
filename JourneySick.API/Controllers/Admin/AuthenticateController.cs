﻿using JourneySick.Business.IServices;
using JourneySick.Data.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace JourneySick.API.Controllers.Admin
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
        [Route("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterRequest registerRequest)
        {
            var result = _authenticateService.RegisterUser(registerRequest);
            return Ok(result);

        }

        //CREATE
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginRequest loginRequest)
        {
            var result = _authenticateService.LoginUser(loginRequest);
            return Ok(result);

        }
    }
}
