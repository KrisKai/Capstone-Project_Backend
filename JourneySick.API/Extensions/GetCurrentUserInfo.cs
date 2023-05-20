using JourneySick.Business.IServices;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.Request;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.API.Extensions
{
    public static class GetCurrentUserInfo
    {
        public static async Task<CurrentUserRequest> GetThisUserInfo(HttpContext httpContext)
        {
            CurrentUserRequest currentUser = new();

            var checkUser = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.SerialNumber);
            if (checkUser != null)
            {
                currentUser.UserId = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.SerialNumber).Value;
                currentUser.Name = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
                currentUser.Role = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            }
            else
            {
                return null;
            }
            return currentUser;
        }
    }
}
