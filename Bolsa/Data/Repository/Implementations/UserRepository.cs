using BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces;
using BackendBolsaDeTrabajoUTN.DBContexts;
using BackendBolsaDeTrabajoUTN.Entities;
using BackendBolsaDeTrabajoUTN.Helpers;
using BackendBolsaDeTrabajoUTN.Models;
using Microsoft.EntityFrameworkCore;


namespace BackendBolsaDeTrabajoUTN.Data.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly TPContext _context;
        public UserRepository(TPContext context)
        {
            _context = context;
        }

        public User? ValidateUser(AuthenticationRequestBody dto)
        {
            var HashPassword = Security.CreateSHA512(dto.Password);
            return _context.Users.SingleOrDefault(u => u.UserName == dto.UserName && u.Password == Security.CreateSHA512(dto.Password) );
        }

        public User? RecoverPassword(PasswordRequestBody dto)
        {
            var user = _context.Users.SingleOrDefault(u => u.UserName == dto.UserName);
            return user ?? null;
        }
    }
}
