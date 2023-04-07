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

namespace JourneySick.API.Controllers
{
    [ApiController]
    [Route("api/v1.0/test")]
    [EnableCors]
    public class TestController : ControllerBase
    {

        public TestController()
        {
        }

        //CREATE
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(string nnn)
        {
            Tbltrip trip = new();
            string ok = checkok(trip);
            
            return Ok(ok);
        }

        private string checkok(dynamic result)
        {
            string checkResult = result.GetType().Name;

            return checkResult;
        }
    }
}
