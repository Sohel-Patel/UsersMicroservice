using eCommers.Core.DTO;

namespace eCommers.Core.ServiceContracts
{
    public interface IUserService
    {
        Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);
        Task<AuthenticationResponse?> Login(LoginRequest loginRequest);
    }
}