using JourneySick.Business.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;
namespace JourneySick.Business.IServices
{
    public interface IAuthenticateService
    {
        public Task<RegisterResponse> RegisterUser(RegisterRequest registereRequest);
        public Task<LoginResponse> Login(LoginRequest loginRequest);
        public Task<LoginResponse> LoginUser(LoginRequest loginRequest);
        public Task<UserVO> GetCurrentInfo(CurrentUserObj currentUser);
    }
}
