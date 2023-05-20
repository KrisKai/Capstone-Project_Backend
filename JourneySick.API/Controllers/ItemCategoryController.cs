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
    [Route("api/v1.0/itemCategories")]
    [EnableCors]
    public class ItemCategoryController : ControllerBase
    {
        private readonly IItemCategoryService _itemCategoryService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ItemCategoryController(IItemCategoryService itemCategoryService, IHttpContextAccessor httpContextAccessor)
        {
            _itemCategoryService = itemCategoryService;
            _httpContextAccessor = httpContextAccessor;
        }

        //GET ALL
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllItemCategorysWithPaging(int pageIndex, int pageSize, string? itemCategoryId)
        {
            var result = new AllItemCategoryDTO();
            CurrentUserRequest currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            result = await _itemCategoryService.GetAllItemCategorysWithPaging(pageIndex, pageSize, itemCategoryId);
            return Ok(result);

        }
        //GET
        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> GetItemCategoryById([FromRoute] int id)
        {
            ItemCategoryDTO result = await _itemCategoryService.GetItemCategoryById(id);
            return Ok(result);

        }


        //CREATE
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateItemCategory([FromBody] ItemCategoryDTO itemCategoryDTO)
        {
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = await _itemCategoryService.CreateItemCategory(itemCategoryDTO, currentUser);
            return Ok(result);

        }

        //UPDATE
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateItemCategory([FromBody] ItemCategoryDTO itemCategoryDTO)
        {
            var currentUser = await GetCurrentUserInfo.GetThisUserInfo(HttpContext);
            var result = await _itemCategoryService.UpdateItemCategory(itemCategoryDTO, currentUser);
            return Ok(result);

        }

        //DELETE BY ID
        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteItemCategory([FromRoute] int id)
        {
            var result = await _itemCategoryService.DeleteItemCategory(id);
            return Ok(result);
        }
    }
}
