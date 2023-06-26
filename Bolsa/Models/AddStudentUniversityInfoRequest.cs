namespace BackendBolsaDeTrabajoUTN.Models
{
    public class AddStudentUniversityInfoRequest
    {
        //// Domicilio familiar

        public string Specialty { get; set; }
        public int ApprovedSubjectsQuantity { get; set; }
        public int SpecialtyPlan { get; set; }
        public int CurrentStudyYear { get; set; }
        public string StudyTurn { get; set; }
        public int AverageMarksWithPostponement { get; set; }
        public int AverageMarksWithoutPostponement { get; set; }
        public string CollegeDegree { get; set; }
    }
}
