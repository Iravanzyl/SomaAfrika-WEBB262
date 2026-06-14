using SomaAfrica.Models;

namespace SomaAfrica.Models
{
    public class DashboardSummary
    {
        public List<Listing> MyListings { get; set; } = new();
        public List<Offer> MyOffers { get; set; } = new();
        public List<Transaction> MyTransactions { get; set; } = new();
        public List<Review> MyReviews { get; set; } = new();
        public List<WishlistItem> MyWishlist { get; set; } = new();
        public double TrustScore { get; set; }
        public int CompletedTransactions { get; set; }
    }
}