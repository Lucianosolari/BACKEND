using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackendBolsaDeTrabajoUTN.Entities
{
    public class CVFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CVId { get; set; }
        public string Name { get; set; }
        public byte[] File { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }
        public int StudentId { get; set; }

        public bool CVIsActive  { get; set; }
    }
}
