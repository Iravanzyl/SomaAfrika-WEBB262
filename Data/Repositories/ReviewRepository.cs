using Microsoft.EntityFrameworkCore;
using SomaAfrica.Data.Interfaces;
using SomaAfrica.Models;

namespace SomaAfrica.Data.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _context;
        public ReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Review> AddReviewAsync(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<Review> GetReviewByTransactionIdAsync(int id)
        {
            return await _context.Reviews.Where(r => r.TransactionId == id).FirstOrDefaultAsync();

        }

        public async Task<List<Review>> GetReviewByUserIdAsync(string id)
        {
            return await _context.Reviews
         .Where(r => r.ReviewedUserId == id)
         .ToListAsync();
        }
    }
}












