using JourneySick.Business.IServices;
using JourneySick.Data.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using System.Net;
using JourneySick.Business.Helpers;
using JourneySick.Data.Models.Entities;
using Org.BouncyCastle.Crmf;
using System.Configuration;
using JourneySick.Business.Extensions.Firebase;

namespace JourneySick.API.Controllers
{
    [ApiController]
    [Route("api/v1.0/test")]
    [EnableCors]
    public class TestController : ControllerBase
    {
        private readonly IFirebaseStorageService _storageService;

        public TestController(IFirebaseStorageService firebaseStorageService)
        {
            _storageService = firebaseStorageService;
        }

        //CREATE
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(IFormFile ok, string dd)
        {
            string link = await _storageService.UploadTripThumbnail(ok, dd);
            return Ok(link);
        }

        private string checkok(dynamic result)
        {
            string checkResult = result.GetType().Name;

            return checkResult;
        }
    }
}
