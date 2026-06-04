using Microsoft.EntityFrameworkCore;
using SomaAfrica.Data;
using SomaAfrica.Models;

namespace SomaAfrica.Services
{
     public class DashboardService
    {
        private readonly ApplicationDbContext _db;

        public DashboardService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<DashboardSummary> GetDashboardAsync(string userId)
        {
            // Get all listings belonging to this user
            var listings = await _db.Listings
                .Include(l => l.Textbook)
                .Where(l => l.UserId == userId)
                .OrderByDescending(l => l.ListingId)
                .ToListAsync();

            // Get all offers where user is buyer OR seller
            var offers = await _db.Offers
                .Include(o => o.Listing)
                    .ThenInclude(l => l.Textbook)
                .Include(o => o.Listing)
                    .ThenInclude(l => l.User)
                .Where(o => o.BuyerId == userId || o.Listing.UserId == userId)
                .OrderByDescending(o => o.OfferId)
                .ToListAsync();

            // Get all transactions where user is buyer OR seller
            var transactions = await _db.Transactions
                .Include(t => t.Offer)
                    .ThenInclude(o => o.Listing)
                        .ThenInclude(l => l.Textbook)
                .Where(t => t.BuyerId == userId || t.SellerId == userId)
                .OrderByDescending(t => t.TransactionDate)
                .ToListAsync();

            // Get all reviews involving this user
            var reviews = await _db.Reviews
                .Include(r => r.Transaction)
                    .ThenInclude(t => t.Offer)
                        .ThenInclude(o => o.Listing)
                            .ThenInclude(l => l.Textbook)
                .Where(r => r.ReviewedUserId == userId || r.ReviewerId == userId)
                .OrderByDescending(r => r.ReviewId)
                .ToListAsync();

            // Calculate Trust Score from reviews received
            var completed = transactions.Count(t => t.Status == "Completed");
            var receivedReviews = reviews.Where(r => r.ReviewedUserId == userId).ToList();

            double trustScore = 0;
            if (receivedReviews.Any())
            {
                trustScore = receivedReviews.Average(r => r.Rating);
                // Small bonus per completed transaction, capped at 5.0
                trustScore = Math.Min(5.0, trustScore + completed * 0.02);
            }

            return new DashboardSummary
            {
                MyListings = listings,
                MyOffers = offers,
                MyTransactions = transactions,
                MyReviews = reviews,
                TrustScore = Math.Round(trustScore, 1),
                CompletedTransactions = completed
            };
        }

        public async Task<double> GetUserTrustScoreAsync(string userId)
        {
            var reviews = await _db.Reviews
                .Where(r => r.ReviewedUserId == userId)
                .ToListAsync();

            if (!reviews.Any()) return 0;

            var completed = await _db.Transactions
                .CountAsync(t =>
                    (t.BuyerId == userId || t.SellerId == userId)
                    && t.Status == "Completed");

            double score = reviews.Average(r => r.Rating);
            score = Math.Min(5.0, score + completed * 0.02);
            return Math.Round(score, 1);
        }
  
    //Wishlist code
// Get wishlist
public async Task<List<WishlistItem>> GetWishlistAsync(string userId)
        {
            return await _db.WishlistItems
                .Include(w => w.Listing)
                    .ThenInclude(l => l.Textbook)
                .Where(w => w.UserId == userId)
                .ToListAsync();
        }

        // Add to wishlist
        public async Task AddToWishlistAsync(string userId, int listingId)
        {
            var exists = await _db.WishlistItems
                .AnyAsync(w => w.UserId == userId && w.ListingId == listingId);

            if (exists) return;

            _db.WishlistItems.Add(new WishlistItem
            {
                UserId = userId,
                ListingId = listingId
            });

            await _db.SaveChangesAsync();
        }

        // Remove from wishlist
        public async Task RemoveFromWishlistAsync(string userId, int listingId)
        {
            var item = await _db.WishlistItems
                .FirstOrDefaultAsync(w => w.UserId == userId && w.ListingId == listingId);

            if (item != null)
            {
                _db.WishlistItems.Remove(item);
                await _db.SaveChangesAsync();
            }
        }
    }
}
    
