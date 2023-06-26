using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using BackendBolsaDeTrabajoUTN.Helpers;

namespace BackendBolsaDeTrabajoUTN.Entities
{
    public class Student : User
    {

        // [Key]

        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        //public int StudentId { get; set; }

        // inicio datos personales
        
        public int File { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string AltEmail { get; set; }
        public string DocumentType { get; set; } // Ver tabla aparte (se repite la palabra)
        public int DocumentNumber { get; set; }
        public long CUIL_CUIT { get; set; }
        public DateTime Birth { get; set; }
        public string Sex { get; set; } //Ver tabla aparte (se repite la palabra)
        public string CivilStatus { get; set; } // Ver tabla aparte (se repite la palabra)

        //// Domicilio familiar

        public string FamilyStreet { get; set; }
        public int FamilyStreetNumber { get; set; }
        public string FamilyStreetLetter { get; set; }
        public int FamilyFloor { get; set; }
        public string FamilyDepartment { get; set; }
        public string FamilyCountry { get; set; }
        public string FamilyProvince { get; set; }
        public string FamilyLocation { get; set; }
        public int FamilyPersonalPhone { get; set; }
        public int FamilyOtherPhone { get; set; }

        ////Domicilio Personal  ?

        public string PersonalStreet { get; set; }
        public int PersonalStreetNumber { get; set; }
        public string PersonalStreetLetter { get; set; }
        public int PersonalFloor { get; set; }
        public string PersonalDepartment { get; set; }
        public string PersonalCountry { get; set; }
        public string PersonalProvince { get; set; }
        public string PersonalLocation { get; set; }
        public int PersonalPersonalPhone { get; set; }
        public int PersonalOtherPhone { get; set; }


        //// Datos universitarios

        public string Specialty { get; set; }
        public int ApprovedSubjectsQuantity { get; set; }
        public int SpecialtyPlan { get; set; }
        public int CurrentStudyYear { get; set; }
        public string StudyTurn { get; set; }
        public int AverageMarksWithPostponement { get; set; }
        public int AverageMarksWithoutPostponement { get; set; }
        public string CollegeDegree { get; set; }


        //// Otros datos

        public string SecondaryDegree { get; set; }
        public string Observations { get; set; }

    
        public ICollection<Knowledge>? Knowledges { get; set; } = new List<Knowledge>();
        public ICollection<Career>? Careers { get; set; } = new List<Career>();
        public ICollection<Offer>? Offers { get; set; } = new List<Offer>();

        public ICollection<StudentKnowledge> StudentKnowledges { get; set; }
        public ICollection<StudentOffer> StudentOffers { get; set; }
    }
}
