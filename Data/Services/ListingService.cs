using Microsoft.EntityFrameworkCore;
using SomaAfrica.Data;
using SomaAfrica.Models;


namespace SomaAfrica.Data.Services
{
    public class ListingService
    {
        private readonly ApplicationDbContext _db;

        public ListingService(ApplicationDbContext db)
        {
            _db = db;
        }

        // Retrieve listing with textbook
        // information for editing
        public async Task<Listing?> GetListingAsync(int id)
        {
            return await _db.Listings
                .Include(l => l.Textbook)
                .FirstOrDefaultAsync(
                    l => l.ListingId == id);
        }

        // Save updates to existing listing
        public async Task UpdateListingAsync(
            Listing listing)
        {
            await _db.SaveChangesAsync();
        }

        // Create textbook first,
        // then create listing
        // to maintain FK integrity
        public async Task<int> CreateListingAsync(
            Textbook textbook,
            Listing listing)
        {
            _db.Textbooks.Add(textbook);

            await _db.SaveChangesAsync();

            listing.TextbookId =
                textbook.TextbookId;

            _db.Listings.Add(listing);

            await _db.SaveChangesAsync();

            return listing.ListingId;
        }
    }
}