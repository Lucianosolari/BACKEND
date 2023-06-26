using BackendBolsaDeTrabajoUTN.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendBolsaDeTrabajoUTN.Models
{
    public class AddOfferRequest
    {

        public string OfferTitle { get; set; }
        // public string OfferType { get; set; }
        public string OfferSpecialty { get; set; }
        public string OfferDescription { get; set; }
        public DateTime CreatedDate { get; set; }

        public int CompanyId { get; set; }

      


      
    }
}
