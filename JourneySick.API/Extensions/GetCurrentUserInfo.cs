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
                currentUser.FldEmail = "";
                currentUser.FldFullname = "";
                currentUser.FldRole = "";
            }
            else
            {
                currentUser.FldUserId = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.SerialNumber).Value;
                currentUser.FldEmail = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
                currentUser.FldRole = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
                currentUser.FldFullname = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Actor).Value;
            }

            UserDTO userDTO = await _userService.SelectUser(currentUser.FldUserId);

            UserDetailDTO userDetailDTO = await _userDetailService.SelectUserDetailByUserName(userDTO.FldUsername);

            //if (userDetailDTO == null)
            //{
            //    currentUser.FldRole = "";
            //}
            //else
            //{
            //    userDetailDTO.FldRole = userDTO.role.id;

            //    if (userDTO.business != null)
            //    {
            //        currentUser.businessId = userDTO.business.id;
            //    }
            //    else
            //    {
            //        currentUser.businessId = "";
            //    }
            //}

            //foreach (RoleDTO role in roleList)
            //{
            //    if (role.name.Equals(Enum.GetNames(typeof(RoleEnum)).ElementAt(0)))
            //    {
            //        currentUser.adminRoleId = role.id;
            //    }
            //    if (role.name.Equals(Enum.GetNames(typeof(RoleEnum)).ElementAt(3)))
            //    {
            //        currentUser.investorRoleId = role.id;
            //    }
            //    if (role.name.Equals(Enum.GetNames(typeof(RoleEnum)).ElementAt(1)))
            //    {
            //        currentUser.businessManagerRoleId = role.id;
            //    }
            //    if (role.name.Equals(Enum.GetNames(typeof(RoleEnum)).ElementAt(2)))
            //    {
            //        currentUser.projectManagerRoleId = role.id;
            //    }
            //}

            //if (currentUser.roleId.Equals(currentUser.projectManagerRoleId))
            //{
            //    //currentUser.projectId = await _userService.GetProjectIdByManagerEmail(currentUser.email);
            //    //currentUser.projectId??="";

            //}

            return currentUser;
        }
    }
}
