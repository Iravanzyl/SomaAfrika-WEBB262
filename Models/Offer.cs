using SomaAfrica.Data;

namespace SomaAfrica.Models;

public class Offer
{
    public int OfferId { get; set; }

    public int ListingId { get; set; }
    public Listing? Listing { get; set; }

    // Who made the offer
    public string BuyerId { get; set; } = string.Empty;
    public ApplicationUser? Buyer { get; set; }

    public decimal ProposedPrice { get; set; }

    // Pending, Accepted, Rejected
    public string Status { get; set; } = "Pending";

    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
}