using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BackendBolsaDeTrabajoUTN.Data.Repository;
using BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces;
using BackendBolsaDeTrabajoUTN.Entities;
using BackendBolsaDeTrabajoUTN.Models;
using System.Security.Claims;
using BackendBolsaDeTrabajoUTN.DBContexts;
using BackendBolsaDeTrabajoUTN.Data.Repository.Implementations;

namespace BackendBolsaDeTrabajoUTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class OfferController : ControllerBase
    {
        private readonly IOfferRepository _offerRepository;

        public OfferController(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        [Authorize]
        [HttpGet("ByCompany/{companyId}")]
        public IActionResult GetOffersByCompany(int companyId)
        {
            var offers = _offerRepository.GetOffersByCompany(companyId);

            if (offers == null)
            {
                return NotFound();
            }

            return Ok(offers);
        }

        [HttpGet("Offers")]
        public IActionResult GetOffers()
        {
            var offers = _offerRepository.GetOffers();
            if (offers == null)
            {
                return NotFound();
            }

            return Ok(offers);
        }

        [Authorize]
        [HttpDelete] 
        [Route("deleteOffer/{offerId}")]
        public IActionResult DeleteOffert(int offerId)
        {
            try
            {
                _offerRepository.DeleteOffer(offerId);
                return Ok("Oferta borrada del sistema.");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

    }
}