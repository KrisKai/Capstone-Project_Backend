using JourneySick.Business.IServices;
using JourneySick.Data.Models.DTOs;
using JourneySick.API.Extensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using Microsoft.AspNetCore.Authorization;
using JourneySick.Data.Models.DTOs.CommonDTO.Request;

namespace JourneySick.API.Controllers
{
    [ApiController]
    [Route("api/v1.0/items")]
    [EnableCors]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ItemController(IItemService itemService, IHttpContextAccessor httpContextAccessor)
        {
            _itemService = itemService;
            _httpContextAccessor = httpContextAccessor;
        }

        //GET ALL
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllItemsWithPaging(int pageIndex, int pageSize, string? itemId, int categoryId)
        {
            CurrentUserObject currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = await _itemService.GetAllItemsWithPaging(pageIndex, pageSize, itemId, categoryId);
            return Ok(result);
        }

        //GET
        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> GetItemById([FromRoute] int id)
        {
            ItemDTO result = await _itemService.GetItemById(id);
            return Ok(result);

        }


        //CREATE
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateItem([FromBody] CreateItemRequest itemRequest)
        {
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = await _itemService.CreateItem(itemRequest, currentUser);
            return Ok(result);

        }

        //UPDATE
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateItem([FromBody] UpdateItemRequest itemRequest)
        {
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = await _itemService.UpdateItem(itemRequest, currentUser);
            return Ok(result);

        }

        //DELETE BY ID
        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteItem([FromRoute] int id)
        {
            var result = await _itemService.DeleteItem(id);
            return Ok(result);
        }
    }
}
