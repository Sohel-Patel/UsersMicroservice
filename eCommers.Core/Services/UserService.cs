using AutoMapper;
using eCommers.Core.DTO;
using eCommers.Core.ServiceContracts;
using eCommers.Domain;
using eCommers.Domain.RepositoryContracts;

namespace eCommers.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
        {
            ApplicationUser? user = await _userRepository.GetUserByEmailAndPassword(loginRequest.Email,loginRequest.Password);

            if (user == null)
            {
                return null;
            }
            
            return _mapper.Map<AuthenticationResponse>(user) with {Success = true,Token = "Token"};
        }

        public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
        {
            ApplicationUser newUser = _mapper.Map<ApplicationUser>(registerRequest);
            ApplicationUser? user = await _userRepository.AddUser(newUser);

            if (user == null)
            {
                return null;
            }

            return _mapper.Map<AuthenticationResponse>(user) with {Success = true,Token = "Token"};
        }
    }
}