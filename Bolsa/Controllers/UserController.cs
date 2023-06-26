using Microsoft.AspNetCore.Mvc;
using BackendBolsaDeTrabajoUTN.Models;
using BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces;
using System.Text;
using System.Configuration;
using BackendBolsaDeTrabajoUTN.DBContexts;
using SendGrid.Helpers.Mail;
using SendGrid;
//using DotNetEnv;


namespace BackendBolsaDeTrabajoUTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly TPContext _context;

        public UserController(IUserRepository userRepository, TPContext context)
        {
            _userRepository = userRepository;
            _context = context;
        }

        [HttpPost]
        [Route("recoverPassword")]
        public IActionResult RecoverPassword(PasswordRequestBody passwordRequestBody)
        {
            var user = _userRepository.RecoverPassword(passwordRequestBody);

            if (user == null)
            {
                return NotFound(); // El usuario no existe
            }

            string newPassword = GenerateRandomPassword();

            user.Password = newPassword; // Actualiza la contraseña del usuario en la base de datos
            _context.SaveChanges(); // Guarda los cambios en la base de datos
            
            SendEmail(user.UserEmail, "Recuperación de contraseña", $"Hola {user.UserName}. Tu nueva contraseña es: {newPassword}");

            return Ok("Cambio correcto"); // Opcionalmente, puedes devolver la nueva contraseña generada como respuesta
        }


        [NonAction]
        private string GenerateRandomPassword()
        {
            string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            Random random = new Random();
            StringBuilder password = new StringBuilder();

            for (int i = 0; i < 8; i++) // Genera una contraseña de longitud 8
            {
                int randomIndex = random.Next(validChars.Length);
                password.Append(validChars[randomIndex]);
            }

            return password.ToString();
        }

        private void SendEmail(string destinatario, string asunto, string contenido)
        {
            //Env.Load(); // Cargar variables de entorno desde el archivo .env

            string apiKey = "API_KEY"; //Env.GetString("API_KEY");

            var client = new SendGridClient(apiKey);


            var from = new EmailAddress("luciano3924@gmail.com", "Bolsa de Trabajo");
            var to = new EmailAddress(destinatario);
            var msg = MailHelper.CreateSingleEmail(from, to, asunto, contenido, contenido);
            try
            {
                var response = client.SendEmailAsync(msg).GetAwaiter().GetResult();
                
            }
            catch (Exception ex)
            {
                // Registra el error o realiza alguna acción de manejo de errores adecuada
                Console.WriteLine($"Error al enviar el correo electrónico: {ex.Message}");
            }
           
        }
    }
}






