namespace SomaAfrica.Models
{
    public class WishlistItem
    {
        public int WishlistItemId { get; set; }

        public string UserId { get; set; } = string.Empty;

        public int ListingId { get; set; }

        public Listing Listing { get; set; }
    }
}