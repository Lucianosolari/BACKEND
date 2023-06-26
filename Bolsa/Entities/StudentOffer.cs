namespace BackendBolsaDeTrabajoUTN.Entities
{
    public class StudentOffer
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int OfferId { get; set; }
        public Offer Offer { get; set; }

        public bool StudentOfferIsActive { get; set; }
    }
}
