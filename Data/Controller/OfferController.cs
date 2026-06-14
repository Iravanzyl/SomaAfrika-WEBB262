using Microsoft.AspNetCore.Mvc;
using SomaAfrica.Data.Services;
using SomaAfrica.Models;

namespace SomaAfrica.Data.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly OfferService _offerService;

        public OfferController(OfferService offerService)
        {
            _offerService = offerService;
        }

        [HttpPost]
        public async Task<ActionResult<Offer>> CreateOffer(Offer offer)
        {
            var createdOffer = await _offerService.CreateOffer(offer);
            return CreatedAtAction(nameof(GetOfferById), new { id = createdOffer.OfferId }, createdOffer);
        }

        [HttpPut("counter")]
        public async Task<ActionResult<Offer>> CounterOffer(Offer offer)
        {
            var updatedOffer = await _offerService.CounterOffer(offer);
            if (updatedOffer == null)
            {
                return NotFound();
            }
            return Ok(updatedOffer);
        }

        [HttpPut("accept/{id}")]
        public async Task<ActionResult<Offer>> AcceptOffer(int id)
        {
            try
            {
                var acceptedOffer = await _offerService.AcceptOffer(id);
                if (acceptedOffer == null)
                {
                    return NotFound();
                }
                return Ok(acceptedOffer);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Offer>> GetOfferById(int id)
        {
            var offer = await _offerService.GetOfferById(id);
            if (offer == null)
            {
                return NotFound();
            }
            return Ok(offer);
        }
    }
}