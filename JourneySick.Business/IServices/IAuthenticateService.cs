using JourneySick.Data.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Business.IServices
{
    public interface IAuthenticateService
    {
        public Task<RegisterResponse> RegisterUser(RegisterRequest registereRequest);
        public Task<LoginResponse> LoginUser(LoginRequest loginRequest);
    }
}
