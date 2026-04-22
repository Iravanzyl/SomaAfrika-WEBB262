using SomaAfrica.Data;

namespace SomaAfrica.Models;

public class WantedAd
{
    public int WantedAdId { get; set; }

    public string UserId { get; set; } = string.Empty;
    public ApplicationUser? User { get; set; }

    // What book they are looking for
    public string Title { get; set; } = string.Empty;

    public string Author { get; set; } = string.Empty;

    // Course or subject code e.g. CS301
    public string Subject { get; set; } = string.Empty;

    // Maximum they are willing to pay
    public decimal MaxPrice { get; set; }

    // Which campus they are on
    public string Campus { get; set; } = string.Empty;

    // When the ad was posted
    public DateTime DatePosted { get; set; } = DateTime.UtcNow;

    // So users can deactivate without deleting
    public bool IsActive { get; set; } = true;
}