using SomaAfrica.Models;

namespace SomaAfrica.Data.Interfaces
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetReviewByUserIdAsync(string id);
        Task<Review> GetReviewByTransactionIdAsync(int id);
        Task<Review> AddReviewAsync(Review review);


    }
}
