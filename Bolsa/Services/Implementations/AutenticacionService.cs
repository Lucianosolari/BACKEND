using BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces;
using BackendBolsaDeTrabajoUTN.Entities;
using BackendBolsaDeTrabajoUTN.Models;
using BackendBolsaDeTrabajoUTN.Services.Interfaces;

namespace BackendBolsaDeTrabajoUTN.Services.Implementations
{
    public class AutenticacionService : ICustomAuthenticationService
    {
        private readonly IUserRepository _userRepository;

        public AutenticacionService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public User? ValidateUser(AuthenticationRequestBody authenticationRequest)
        {
            if (string.IsNullOrEmpty(authenticationRequest.UserName) || string.IsNullOrEmpty(authenticationRequest.Password) )
                return null;
            return _userRepository.ValidateUser(authenticationRequest);
        }
    }
}
