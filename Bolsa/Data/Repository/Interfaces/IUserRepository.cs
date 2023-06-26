using BackendBolsaDeTrabajoUTN.Entities;
using BackendBolsaDeTrabajoUTN.Models;


namespace BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        public User? ValidateUser(AuthenticationRequestBody user);
        public User? RecoverPassword(PasswordRequestBody user);
    }
}
