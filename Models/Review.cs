namespace SomaAfrica.Models;
public class Review
{
    public int ReviewId { get; set; }

    public int TransactionId { get; set; }
    public Transaction Transaction { get; set; }

    public string ReviewerId { get; set; }
    public string ReviewedUserId { get; set; }

    public int Rating { get; set; }
    public string Comment { get; set; }
}
