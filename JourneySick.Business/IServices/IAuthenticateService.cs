using JourneySick.Data.Models.DTOs.CommonDTO.Request;
namespace JourneySick.Business.IServices
{
    public interface IAuthenticateService
    {
        public Task<RegisterResponse> RegisterUser(RegisterRequest registereRequest);
        public Task<LoginResponse> Login(LoginRequest loginRequest);
        public Task<LoginResponse> LoginUser(LoginRequest loginRequest);
        public Task<LoginResponse> LoginWithSocial(string firebaseToken);
        public Task<LoginResponse> RegisterWithSocial(string firebaseToken);
        public Task<UserRequest> GetCurrentInfo(CurrentUserObject currentUser);
    }
}
