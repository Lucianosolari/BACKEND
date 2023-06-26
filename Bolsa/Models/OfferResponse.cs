using BackendBolsaDeTrabajoUTN.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendBolsaDeTrabajoUTN.Models
{
    public class OfferResponse
    {
        public int OfferId { get; set; }
        public string OfferTitle { get; set; }
      
        public string OfferSpecialty { get; set; }
        public string OfferDescription { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<Student>? Students { get; set; } = new List<Student>();
        public ICollection<StudentOffer> StudentOffers { get; set; }

        public bool OfferIsActive { get; set; }
        public int CompanyId { get; set; }


    }
}
