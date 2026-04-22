using Microsoft.EntityFrameworkCore;
using SomaAfrica.Data;
using SomaAfrica.Models;

namespace SomaAfrica.Services
{
    public class SearchFilter
    {
        public string? Query { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? Condition { get; set; }
        public string? Campus { get; set; }
        public string SortBy { get; set; } = "date";
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 9;
    }

    public class PagedResult<T>
    {
        public List<T> Items { get; set; } = new();
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
        public bool HasPrev => Page > 1;
        public bool HasNext => Page < TotalPages;
    }

    public class SearchService
    {
        private readonly ApplicationDbContext _db;

        public SearchService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<PagedResult<Listing>> SearchListingsAsync(SearchFilter filter)
        {
            var query = _db.Listings
                .Include(l => l.Textbook)
                .Include(l => l.User)
                .Where(l => l.Status == "Active")
                .AsQueryable();

            // Multi-field search: title, author, ISBN, subject/course code
            if (!string.IsNullOrWhiteSpace(filter.Query))
            {
                var q = filter.Query.ToLower();
                query = query.Where(l =>
                    l.Textbook.Title.ToLower().Contains(q) ||
                    l.Textbook.Author.ToLower().Contains(q) ||
                    l.Textbook.ISBN.ToLower().Contains(q) ||
                    l.Textbook.Subject.ToLower().Contains(q));
            }

            // Price range filter
            if (filter.MinPrice.HasValue)
                query = query.Where(l => l.Price >= filter.MinPrice.Value);

            if (filter.MaxPrice.HasValue)
                query = query.Where(l => l.Price <= filter.MaxPrice.Value);

            // Condition filter
            if (!string.IsNullOrWhiteSpace(filter.Condition))
                query = query.Where(l => l.Condition == filter.Condition);

            // Campus filter
            if (!string.IsNullOrWhiteSpace(filter.Campus))
                query = query.Where(l => l.CampusLocation == filter.Campus);

            // Sorting
            query = filter.SortBy switch
            {
                "price_asc" => query.OrderBy(l => l.Price),
                "price_desc" => query.OrderByDescending(l => l.Price),
                _ => query.OrderByDescending(l => l.ListingId)
            };

            var total = await query.CountAsync();

            var items = await query
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return new PagedResult<Listing>
            {
                Items = items,
                TotalCount = total,
                Page = filter.Page,
                PageSize = filter.PageSize
            };
        }

        public async Task<List<string>> GetCampusesAsync()
        {
            return await _db.Listings
                .Where(l => l.CampusLocation != null)
                .Select(l => l.CampusLocation)
                .Distinct()
                .OrderBy(c => c)
                .ToListAsync();
        }
    }
}