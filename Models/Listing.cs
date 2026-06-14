using SomaAfrica.Data;

namespace SomaAfrica.Models;

public class Listing
{
    public int ListingId { get; set; }

    public string UserId { get; set; } = string.Empty;
    public ApplicationUser? User { get; set; }

    public int TextbookId { get; set; }
    public Textbook? Textbook { get; set; }

    public decimal Price { get; set; }

    public string Condition { get; set; } = "Good";

    public string CampusLocation { get; set; } = string.Empty;

    public string Status { get; set; } = "Active";

    // Optional image URL for the textbook cover
    public string? ImageUrl { get; set; }

    // When the listing was posted
    public DateTime DatePosted { get; set; } = DateTime.UtcNow;

    public ICollection<Offer>? Offers { get; set; }
}
