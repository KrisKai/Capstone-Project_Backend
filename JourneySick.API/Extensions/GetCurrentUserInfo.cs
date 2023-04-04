using JourneySick.Business.IServices;
using JourneySick.Data.Models.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.API.Extensions
{
    internal static class GetCurrentUserInfo
    {
        internal static async Task<UserDetailDTO> GetThisUserInfo(HttpContext httpContext, IUserService _userService, IUserDetailService _userDetailService)
        {
            UserDetailDTO currentUser = new();

            var checkUser = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.SerialNumber);
            if (checkUser == null)
            {
                currentUser.FldUserId = "";
                currentUser.FldRole = "";
            }
            else
            {
                currentUser.FldUserId = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.SerialNumber).Value;
                currentUser.FldRole = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            }

            UserDTO userDTO = await _userService.GetUserById(currentUser.FldUserId);

            UserDetailDTO userDetailDTO = await _userDetailService.GetUserDetailByUserName(userDTO.FldUsername);

            return currentUser;
        }
    }
}
