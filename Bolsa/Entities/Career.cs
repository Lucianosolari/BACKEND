using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendBolsaDeTrabajoUTN.Entities
{
    public class Career
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CareerId { get; set; }
        public string CareerName { get; set; }
        public string CareerAbbreviation { get; set; }
        public string CareerType { get; set; }
        public int CareerTotalSubjects { get; set; }
        public ICollection<Student>? Students { get; set; } = new List<Student>();

        public bool CareerIsActive { get; set; }
    }
}
