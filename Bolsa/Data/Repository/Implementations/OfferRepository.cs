using BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces;
using BackendBolsaDeTrabajoUTN.Entities;
using BackendBolsaDeTrabajoUTN.Models;
using BackendBolsaDeTrabajoUTN.DBContexts;
using BackendBolsaDeTrabajoUTN.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendBolsaDeTrabajoUTN.Data.Repository
{
    public class OfferRepository : IOfferRepository
    {
        
        private readonly TPContext _context;
        public OfferRepository(TPContext context)
        {
            _context = context;
        }

        public List<Offer> GetOffersByCompany(int companyId)
        {
            try
            {
                var offers = _context.Offers.Where(o => o.CompanyId == companyId && o.OfferIsActive == true).ToList();
                return offers;
            }
            catch
            {
                throw new Exception("La empresa no tiene ofertas");
            }
        }

        public void DeleteOffer(int offerId)
        {
            var offer = _context.Offers.FirstOrDefault(o => o.OfferId == offerId);
            if (offer == null )
            {
                throw new Exception("No existe la oferta o el estudiante");
            }
            offer.OfferIsActive = false;
            _context.SaveChanges();
        }


        public ActionResult<IEnumerable<Offer>> GetOffers()
        {
            try
            {
                return _context.Offers
                .Where(o => o.OfferIsActive == true)
                .Include(o => o.Company)
                .ToList();
            }
            catch
            {
                throw new Exception("No se encontraron ofertas");
            }
        }
    }
}