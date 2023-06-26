using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BackendBolsaDeTrabajoUTN.Data.Repository;
using BackendBolsaDeTrabajoUTN.Entities;
using BackendBolsaDeTrabajoUTN.Models;
using BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces;
using BackendBolsaDeTrabajoUTN.Data.Repository.Implementations;
using System.Text.RegularExpressions;

namespace BackendBolsaDeTrabajoUTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentOfferRepository _studentOfferRepository;
        public CompanyController(ICompanyRepository companyRepository, IStudentRepository studentRepository, IStudentOfferRepository studentOfferRepository)
        {
            _companyRepository = companyRepository;
            _studentRepository = studentRepository;
            _studentOfferRepository = studentOfferRepository;
        }

        [HttpPost]
        [Route("createCompany")]
        public IActionResult CreateCompany(AddCompanyRequest request)
        {
            //var userType = User.Claims.FirstOrDefault(c => c.Type == "userType")?.Value;
            //if (userType == "Admin")
            //{
                try
                {
                    List<User> users = _companyRepository.GetUsers();
                    List<Student> students = _studentRepository.GetStudents();
                    List<Company> companies = _companyRepository.GetCompanies();
                    ValidateUserName(users, request.UserName);
                    ValidatePassword(request.Password, request.ConfirmPassword, request.UserName);
                    ValidateCUIT(companies, students, request.CompanyCUIT);
                    ValidateCompanyName(companies, request.CompanyName);
                    ValidatePhoneNumbers(companies, request.CompanyPhone, request.CompanyPersonalPhone);
                    ValidateEmail(users, students, request.UserEmail);

                    Company newCompany = new()
                    {
                        // datos de la empresa
                        UserName = request.UserName,
                        Password = request.Password,
                        CompanyCUIT = request.CompanyCUIT,
                        CompanyLine = request.CompanyLine,
                        CompanyName = request.CompanyName,
                        CompanyAddress = request.CompanyAddress,
                        CompanyLocation = request.CompanyLocation,
                        CompanyPostalCode = request.CompanyPostalCode,
                        CompanyPhone = request.CompanyPhone,
                        UserIsActive = true,

                        // datos de contacto
                        CompanyWebPage = request.CompanyWebPage,
                        CompanyPersonalName = request.CompanyPersonalName,
                        CompanyPersonalSurname = request.CompanyPersonalSurname,
                        CompanyPersonalJob = request.CompanyPersonalJob,
                        CompanyPersonalPhone = request.CompanyPersonalPhone,
                        UserEmail = request.UserEmail.ToLower(),
                        CompanyRelationContact = request.CompanyRelationContact,
                        CompanyPendingConfirmation = true
                    };
                    CompanyResponse response = new()
                    {
                        CompanyName = newCompany.CompanyName,
                    };
                    _companyRepository.CreateCompany(newCompany);
                    return Created("Empresa creada", response);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            //}
            //else
            //{
            //    return BadRequest("El usuario no esta autorizado para crear ofertas");
            //}
        }

        [Authorize]
        [HttpDelete]
        [Route("deleteCompany/{id}")]
        public IActionResult DeleteCompany(int id)
        {
            try
            {
                _companyRepository.RemoveCompany(id);
                return Ok("Empresa borrada del sistema.");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        [Route("createOffer")]
        public IActionResult CreateOffer(AddOfferRequest request)
        {
            var userType = User.Claims.FirstOrDefault(c => c.Type == "userType")?.Value;
            if (userType == "Company")
            {
                try
                {
                    Offer newOffer = new()
                    {
                        OfferTitle = request.OfferTitle,
                        OfferSpecialty = request.OfferSpecialty,
                        OfferDescription = request.OfferDescription,
                        CreatedDate = request.CreatedDate,
                        CompanyId = request.CompanyId,
                        OfferIsActive = true,
                    };
                    OfferResponse response = new()
                    {
                        OfferTitle = newOffer.OfferTitle,
                        OfferSpecialty = newOffer.OfferSpecialty,
                        OfferDescription = newOffer.OfferDescription,
                        CreatedDate = newOffer.CreatedDate,
                        OfferIsActive = true,
                };
                    _companyRepository.CreateOffer(newOffer);
                    return Created("Oferta creada", response);
                }
                catch (Exception ex)
                {
                    return Problem(ex.Message);
                }
            }
            else
            {
                return BadRequest("El usuario no esta autorizado para crear ofertas");
            }
        }

        [HttpGet]
        [Route("{offerId}/getStudentsInOffer")]
        public ActionResult GetStudentsInOffer(int offerId)
        {
            var userType = User.Claims.FirstOrDefault(c => c.Type == "userType")?.Value;
            if (userType == "Company")
            {
                try
                {
                    var studentsInOffer = _studentOfferRepository.GetStudentsInOffers(offerId);
                    if (studentsInOffer.Any())
                    {
                        return Ok(studentsInOffer);
                    }
                        return BadRequest("No hay estudiantes en esta oferta");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest("No autorizado");
            }
        }

        [HttpGet]
        [Route("CVFiles/{userId}/getStudentCV")]
        public ActionResult GetStudentCV(int userId)
        {
            try
            {
                var student = _studentRepository.GetStudentById(userId);
                var cv = _companyRepository.GetStudentCv(student.UserId);
                return File(cv.File, "application/octet-stream", cv.Name);
            }
            catch
            {
                return BadRequest("CV o usuario no encontrado");
            }

        }

        [NonAction]
        public void ValidateUserName(List<User> users, string userName)
        {
            var inUse = users.FirstOrDefault(u => u.UserName.ToLower() == userName.ToLower());
            if (inUse != null)
            {
                throw new Exception("Nombre de usuario ya utilizado");
            }
        }

        [NonAction]
        public void ValidateCUIT(List<Company> companies, List<Student> students, long CUIT)
        {
            try
            {
                if (CUIT.ToString().Length != 11)
                {
                    throw new Exception("CUIT no válido, debe tener una longitud de 11 dígitos.");
                }
                var inUseCompany = companies.FirstOrDefault(c => c.CompanyCUIT == CUIT);
                var inUseStudent = students.FirstOrDefault(s => s.CUIL_CUIT == CUIT);
                if (inUseCompany != null || inUseStudent != null)
                {
                    throw new Exception("CUIT ya registrado");
                }
            }
            catch (FormatException)
            {
                throw new Exception("El CUIT debe ser un número entero.");
            }
        }

        [NonAction]
        public void ValidateCompanyName(List<Company> companies, string companyName)
        {
            var inUse = companies.FirstOrDefault(c => c.CompanyName.ToLower() == companyName.ToLower());
            if (inUse != null)
            {
                throw new Exception("Nombre de empresa ya utilizado");
            }
        }

        [NonAction]
        public void ValidateEmail(List<User> users, List<Student> students, string email)
        {
            try
            {
                if (email.EndsWith("@frro.utn.edu.ar"))
                {
                    throw new Exception("Correo electrónico no válido, está introduciendo uno institucional");
                }
                if (!IsValidEmail(email))
                {
                    throw new Exception("Correo electrónico no válido");
                }
                var inUseUser = users.FirstOrDefault(u => u.UserEmail.ToLower() == email.ToLower());
                var inUseStudent = students.FirstOrDefault(s => s.AltEmail.ToLower() == email.ToLower());
                if (inUseUser != null ||inUseStudent != null)
                {
                    throw new Exception("Correo electrónico ya registrado");
                }
            }
            catch (FormatException)
            {
                throw new Exception("El correo electrónico debe ser válido");
            }
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);

                if (!Regex.IsMatch(addr.Host, @"^[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                {
                    return false;
                }

                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        [NonAction]
        public void ValidatePhoneNumbers(List<Company> companies, long companyPhone, long companyPersonalPhone)
        {
            try
            {
                if (companyPhone.ToString().Length != 10)
                {
                    throw new Exception("Teléfono de empresa no válido, debe tener 10 dígitos");
                }
                if (companyPersonalPhone.ToString().Length != 10)
                {
                    throw new Exception("Teléfono personal no válido, debe tener 10 dígitos");
                }

                if (companyPhone == companyPersonalPhone)
                {
                    throw new Exception("El teléfono de empresa y el personal deben ser diferentes");
                }

                var companyPhoneInUse = companies.FirstOrDefault(c => c.CompanyPhone == companyPhone);
                var companyPersonalPhoneInUse = companies.FirstOrDefault(c => c.CompanyPersonalPhone == companyPersonalPhone);

                if (companyPhoneInUse != null)
                {
                    throw new Exception("El teléfono de empresa introducido ya está en uso");
                }
                if (companyPersonalPhoneInUse != null)
                {
                    throw new Exception("El teléfono personal introducido ya está en uso");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [NonAction]
        public void ValidatePassword(string password, string confirmPassword, string userName)
        {
            try
            {
                if (password.Length < 8)
                {
                    throw new Exception("Contraseña insegura, debe tener al menos 8 caracteres");
                }

                bool hasUpperCase = password.Any(char.IsUpper);
                bool hasLowerCase = password.Any(char.IsLower);
                bool hasDigit = password.Any(char.IsDigit);
                bool hasSpecialChar = password.Any(c => !char.IsLetterOrDigit(c));

                if (!hasUpperCase || !hasLowerCase || !hasDigit || !hasSpecialChar)
                {
                    throw new Exception("Contraseña insegura, debe contener al menos una letra mayúscula, una minúscula, un número y un caracter especial");
                }

                if (password == userName)
                {
                    throw new Exception("Contraseña insegura, no puede ser igual al nombre de usuario");
                }

                if (password != confirmPassword)
                {
                    throw new Exception("Los campos introducidos de contraseña no coinciden");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}