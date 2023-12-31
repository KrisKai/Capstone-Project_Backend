﻿using JourneySick.API.Extensions;
using JourneySick.Business.IServices;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.Request;

namespace JourneySick.API.Controllers
{
    [ApiController]
    [Route("api/v1.0/feedbacks")]
    [EnableCors]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public FeedbackController(IFeedbackService feedbackService, IHttpContextAccessor httpContextAccessor)
        {
            _feedbackService = feedbackService;
            _httpContextAccessor = httpContextAccessor;
        }

        //GET ALL
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllFeedbacksWithPaging(int pageIndex, int pageSize, string? tripId)
        {
            var result = new AllFeedbackDTO();
            result = await _feedbackService.GetAllFeedbacksWithPaging(pageIndex, pageSize, tripId);
            return Ok(result);

        }

        //GET
        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> GetFeedbackById([FromRoute] int id)
        {
            var result = await _feedbackService.GetFeedbackById(id);
            return Ok(result);
        }

        //CREATE
        [HttpPost]
        //[Route("create-admin")]
        [Authorize]
        public async Task<IActionResult> CreateFeedback([FromBody] CreateFeedbackRequest feedbackRequest)
        {
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = await _feedbackService.CreateFeedback(feedbackRequest, currentUser);
            return Ok(result);

        }

        //UPDATE
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateFeedback([FromBody] UpdateFeedbackRequest feedbackRequest)
        {
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = await _feedbackService.UpdateFeedback(feedbackRequest, currentUser);
            return Ok(result);

        }

        //DELETE BY ID
        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            var result = await _feedbackService.DeleteFeedback(id);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("get-top-feedback")]
        public async Task<IActionResult> GetTopFeedback()
        {
            var result = await _feedbackService.GetTopFeedback();
            return Ok(result);
        }

        //UPDATE
        [AllowAnonymous]
        [HttpPut]
        [Route("increase-like")]
        public async Task<IActionResult> IncreaseLike([FromBody] int feedbackId, string status)
        {
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = await _feedbackService.IncreaseLike(feedbackId, status);
            return Ok(result);

        }
    }

}
