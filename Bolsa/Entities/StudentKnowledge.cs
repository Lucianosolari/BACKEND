using System.ComponentModel.DataAnnotations.Schema;


namespace BackendBolsaDeTrabajoUTN.Entities
{
    public class StudentKnowledge
    {
       
         [ForeignKey(nameof(Student))]
         public int UserId { get; set; }
         public Student Student { get; set; }

         [ForeignKey(nameof(Knowledge))]
         public int KnowledgeId { get; set; }
         public Knowledge Knowledge { get; set; }

         public bool StudentKnowledgeIsActive { get; set; }
        
    }
}
