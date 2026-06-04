using SomaAfrica.Data.Interfaces;
using SomaAfrica.Models;

namespace SomaAfrica.Data.Services
{
    public class ReviewServices
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewServices(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<Review> AddReviewAsync(Review review)
        {
            return await _reviewRepository.AddReviewAsync(review);
        }

        public async Task<Review> GetReviewByTransactionIdAsync(int id)
        {
            return await _reviewRepository.GetReviewByTransactionIdAsync(id);
        }

        public async Task<List<Review>> GetReviewByUserIdAsync(string id)
        {
            return await _reviewRepository.GetReviewByUserIdAsync(id);
        }



    }
}
