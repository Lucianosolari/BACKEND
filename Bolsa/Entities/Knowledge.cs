using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendBolsaDeTrabajoUTN.Entities
{
    public class Knowledge
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KnowledgeId { get; set; }
        public string Type { get; set; }
        public string Level { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<StudentKnowledge> StudentKnowledges { get; set; }

        public bool KnowledgeIsActive { get; set; }
    }
}