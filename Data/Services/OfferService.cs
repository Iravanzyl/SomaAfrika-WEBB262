using SomaAfrica.Data.Interfaces;
using SomaAfrica.Models;

namespace SomaAfrica.Data.Services
{
    public class OfferService
    {
        private readonly IOffersRepository _offerRepository;

        public OfferService(IOffersRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public async Task<Offer> CreateOffer(Offer offer)
        {
            return await _offerRepository.CreateOffer(offer);
        }

        public async Task<Offer> CounterOffer(Offer offer)
        {
            return await _offerRepository.CounterOffer(offer);
        }

        public async Task<Offer> AcceptOffer(int offerId)
        {
            return await _offerRepository.AcceptOffer(offerId);
        }

        public async Task<Offer> GetOfferById(int offerId)
        {
            return await _offerRepository.GetOfferById(offerId);
        }


    }
}
