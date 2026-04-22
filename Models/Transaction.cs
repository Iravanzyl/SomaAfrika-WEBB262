namespace SomaAfrica.Models;

public class Transaction
{
    public int TransactionId { get; set; }

    public int OfferId { get; set; }
    public Offer? Offer { get; set; }

    public string BuyerId { get; set; } = string.Empty;
    public string SellerId { get; set; } = string.Empty;

    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;

    // CashOnMeetup, EFT, Other
    public string PaymentMethod { get; set; } = "CashOnMeetup";

    public string MeetupLocation { get; set; } = string.Empty;

    // Pending, Completed
    public string Status { get; set; } = "Pending";
}
