using BackendBolsaDeTrabajoUTN.Entities;

namespace BackendBolsaDeTrabajoUTN.Models
{
    public class AddCompanyRequest
    {
        // datos de la empresa
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string CompanyName { get; set; } //razón social
        public long CompanyCUIT { get; set; }
        public string CompanyLine { get; set; } //rubro
        public string CompanyAddress { get; set; }
        public string CompanyLocation { get; set; }
        public string CompanyPostalCode { get; set; }
        public long CompanyPhone { get; set; }
        public string CompanyWebPage { get; set; }

        // datos de contacto
        public string CompanyPersonalName { get; set; }
        public string CompanyPersonalSurname { get; set; }
        public string CompanyPersonalJob { get; set; }
        public long CompanyPersonalPhone { get; set; }
        public string UserEmail { get; set; }
        public string CompanyRelationContact { get; set; } //ver

    }
}