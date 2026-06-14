using Microsoft.EntityFrameworkCore;
using SomaAfrica.Data.Interfaces;
using SomaAfrica.Models;

namespace SomaAfrica.Data.Repositories
{
    public class OfferRepository : IOffersRepository
    {
        private readonly ApplicationDbContext _context;
        public OfferRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Offer> CreateOffer(Offer offer)
        {
            _context.Offers.Add(offer);
            await _context.SaveChangesAsync();
            return offer;
        }
        public async Task<Offer> CounterOffer(Offer offer)
        {
            var existingOffer = await _context.Offers.FindAsync(offer.OfferId);
            if (existingOffer == null)
            {
                return null;
            }
            existingOffer.ProposedPrice = offer.ProposedPrice;
            existingOffer.IsAccepted = false; // Reset acceptance status for counteroffer
            await _context.SaveChangesAsync();
            return existingOffer;
        }
        public async Task<Offer> AcceptOffer(int offerId)
        {
            var offer = await _context.Offers.FindAsync(offerId);
            if (offer == null)
            {
                return null;
            }

            // Check if another offer for the same listing is already accepted
            var alreadyAccepted = await _context.Offers
                .AnyAsync(o => o.ListingId == offer.ListingId && o.IsAccepted && o.OfferId != offerId);

            if (alreadyAccepted)
            {
                throw new InvalidOperationException("Another offer for this listing has already been accepted.");
            }

            offer.IsAccepted = true;
            await _context.SaveChangesAsync();
            return offer;
        }

        public async Task<Offer> GetOfferById(int offerId)
        {
            var offer = await _context.Offers.FindAsync(offerId);
            return offer;
        }
    }



}
