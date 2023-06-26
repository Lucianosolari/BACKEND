namespace BackendBolsaDeTrabajoUTN.Entities
{
    public class StudentCareer
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CareerId { get; set; }
        public Career Career { get; set; }

        public bool StudentCareerIsActive { get; set; }
    }
}
