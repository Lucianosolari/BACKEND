namespace BackendBolsaDeTrabajoUTN.Models
{
    public class AddCareerRequest
    {
        public string CareerName { get; set; }
        public string CareerAbbreviation { get; set; }
        public string CareerType { get; set; }
        public int CareerTotalSubjects { get; set; }
    }
}
