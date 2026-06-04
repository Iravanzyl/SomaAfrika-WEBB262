using SomaAfrica.Models;

namespace SomaAfrica.Data.Interfaces
{
    public interface IOffersRepository
    {
        Task<Offer> CreateOffer(Offer offer);
        Task<Offer> CounterOffer(Offer offer);
        Task<Offer> AcceptOffer(int offerId);
        Task<Offer> GetOfferById(int offerId);

    }
}
