using BackendBolsaDeTrabajoUTN.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces
{
    public interface IOfferRepository
    {
        //public Offer? GetSingleTrial(int id);
        //public List<Offer> GetTrials();
        //public void AddTrial(Offer trial);
        //public void RemoveTrial(int id);
        //public void EditTrialDistance(int id, int newDistance);
        //public void EditTrialStyle(int id, string newStyle);
        //public List<Company> GetExistingMeets();
        //public List<Student> GetRegisteredSwimmers(int id);
        //public Company GetTrialMeet(int id);
        //public string GetTrialMeetName(int id);
        //public List<Meet> GetSingleMeet(int id);

        
        public List<Offer> GetOffersByCompany(int companyId);
        public void DeleteOffer(int offerId);
        public ActionResult<IEnumerable<Offer>> GetOffers();
    }
}
