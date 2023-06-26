using Microsoft.AspNetCore.Mvc;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using BackendBolsaDeTrabajoUTN.Models;
using BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces;
using BackendBolsaDeTrabajoUTN.DBContexts;
using BackendBolsaDeTrabajoUTN.Entities;

namespace BackendBolsaDeTrabajoUTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepository;
        private readonly TPContext _context;

        public AuthenticationController(IConfiguration config, IUserRepository userRepository, TPContext context )
        {
            _config = config; //Hacemos la inyección para poder usar el appsettings.json
            _userRepository = userRepository;
            _context = context;

        }

        [HttpPost("authenticate")] //Vamos a usar un POST ya que debemos enviar los datos para hacer el login
        public ActionResult<string> Autenticar(AuthenticationRequestBody authenticationRequestBody) //Enviamos como parámetro la clase que creamos arriba
        {
            //Paso 1: Validamos las credenciales
            var user = _userRepository.ValidateUser(authenticationRequestBody); //Lo primero que hacemos es llamar a una función que valide los parámetros que enviamos.
            if (user is null)
                return Unauthorized();

            var company = _context.Companies
            .Where(u => u.UserId == user.UserId && u.CompanyPendingConfirmation)
            .FirstOrDefault();

            if (user.UserIsActive == false )
            {
                return BadRequest(new { error = "Su cuenta no extiste, fue eliminada" });
            }

            if (user.UserType == "Company" && company != null && company.CompanyPendingConfirmation)
            {
                return BadRequest(new { error = "Su empresa se encuentra pendiente de autorizar, comuníquese con el administrador" });
            }

            //Paso 2: Crear el token
            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"])); //Traemos la SecretKey del Json. agregar antes: using Microsoft.IdentityModel.Tokens;

            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            //Los claims son datos en clave->valor que nos permite guardar data del usuario.
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.UserId.ToString())); //"sub" es una key estándar que significa unique user identifier, es decir, si mandamos el id del usuario por convención lo hacemos con la key "sub".
            claimsForToken.Add(new Claim("given_name", user.UserName)); //cambiar todo a user y no student //Lo mismo para given_name y family_name, son las convenciones para nombre y apellido. Ustedes pueden usar lo que quieran, pero si alguien que no conoce la app //quiere usar la API por lo general lo que espera es que se estén usando estas keys //Debería venir del usuario
            if (user.UserType == "Company")
            {
                claimsForToken.Add(new Claim("role", "Company"));
            }
            else if (user.UserType == "Admin") // si el usuario es un Admin, agregar el claim de 'role' con el valor 'Admin'
            {
                claimsForToken.Add(new Claim("role", "Admin"));
            }
            else
            {
                claimsForToken.Add(new Claim("role", "Student"));
            }

            claimsForToken.Add(new Claim("userType", user.UserType));


            var jwtSecurityToken = new JwtSecurityToken( //agregar using System.IdentityModel.Tokens.Jwt; Acá es donde se crea el token con toda la data que le pasamos antes.
              _config["Authentication:Issuer"],
              _config["Authentication:Audience"],
              claimsForToken,
              DateTime.UtcNow,
              DateTime.UtcNow.AddHours(1),
              credentials);

            var tokenToReturn = new JwtSecurityTokenHandler() //Pasamos el token a string
                .WriteToken(jwtSecurityToken);

            return Ok(new { Token = tokenToReturn, UserType = user.UserType, UserId = user.UserId });
        }

       

        [HttpPost("logout")]
        public IActionResult Logout()
        {
           
            HttpContext.Response.Cookies.Delete("token");
           
            return Ok(new { Message = "Logout successful" });
        }

    }
}
