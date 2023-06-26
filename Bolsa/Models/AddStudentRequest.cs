using BackendBolsaDeTrabajoUTN.Helpers;
using System.ComponentModel.DataAnnotations;

namespace BackendBolsaDeTrabajoUTN.Models
{
    public class AddStudentRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int File { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserEmail { get; set; }

        public string AltEmail { get; set; }
        public string DocumentType { get; set; } // Ver tabla aparte (se repite la palabra)

        public int DocumentNumber { get; set; }

        public long CUIL_CUIT { get; set; }

        public DateTime Birth { get; set; }

        public string Sex { get; set; } //Ver tabla aparte (se repite la palabra)
        public string CivilStatus { get; set; } // Ver tabla aparte (se repite la palabra)
    }
}
