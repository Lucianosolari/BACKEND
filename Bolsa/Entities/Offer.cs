using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendBolsaDeTrabajoUTN.Entities
{
    public class Offer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OfferId { get; set; }
        public string OfferTitle { get; set; }
       
        public string OfferSpecialty { get; set; }
        public string OfferDescription { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<Student>? Students { get; set; } = new List<Student>();
        public ICollection<StudentOffer> StudentOffers { get; set; }


        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        public int CompanyId { get; set; }

        public bool OfferIsActive { get; set; }
    }
}
