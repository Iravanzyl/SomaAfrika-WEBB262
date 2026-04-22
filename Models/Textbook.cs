namespace SomaAfrica.Models;
public class Textbook
{
    public int TextbookId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public string Subject { get; set; }

    public ICollection<Listing> Listings { get; set; }
}