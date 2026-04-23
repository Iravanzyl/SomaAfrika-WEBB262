using Microsoft.AspNetCore.Identity;
using SomaAfrica.Models;

namespace SomaAfrica.Data
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(
            ApplicationDbContext db,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            // Ensure database is created
            db.Database.EnsureCreated();

            // ── Seed Roles ────────────────────────────────────────────
            string[] roles = { "Admin", "Seller", "Buyer" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            // ── Seed Admin User ───────────────────────────────────────
            var admin = await userManager.FindByEmailAsync("admin@stadio.ac.za");
            if (admin == null)
            {
                admin = new ApplicationUser
                {
                    UserName = "admin@stadio.ac.za",
                    Email = "admin@stadio.ac.za",
                    EmailConfirmed = true,
                    TrustScore = 5.0m,
                    LanguagePreference = "en"
                };
                await userManager.CreateAsync(admin, "Admin@123");
                await userManager.AddToRoleAsync(admin, "Admin");
            }

            // ── Seed Seller User ──────────────────────────────────────
            var seller = await userManager.FindByEmailAsync("seller@stadio.ac.za");
            if (seller == null)
            {
                seller = new ApplicationUser
                {
                    UserName = "seller@stadio.ac.za",
                    Email = "seller@stadio.ac.za",
                    EmailConfirmed = true,
                    TrustScore = 4.5m,
                    LanguagePreference = "en"
                };
                await userManager.CreateAsync(seller, "Seller@123");
                await userManager.AddToRoleAsync(seller, "Seller");
            }

            // ── Seed Buyer User ───────────────────────────────────────
            var buyer = await userManager.FindByEmailAsync("buyer@stadio.ac.za");
            if (buyer == null)
            {
                buyer = new ApplicationUser
                {
                    UserName = "buyer@stadio.ac.za",
                    Email = "buyer@stadio.ac.za",
                    EmailConfirmed = true,
                    TrustScore = 4.0m,
                    LanguagePreference = "en"
                };
                await userManager.CreateAsync(buyer, "Buyer@123");
                await userManager.AddToRoleAsync(buyer, "Buyer");
            }

            // ── Seed Textbooks & Listings ─────────────────────────────
            if (!db.Listings.Any())
            {
                var textbooks = new List<Textbook>
                {
                    new Textbook
                    {
                        Title   = "Introduction to Algorithms",
                        Author  = "Thomas Cormen",
                        ISBN    = "978-0-262-03384-8",
                        Subject = "CS301"
                    },
                    new Textbook
                    {
                        Title   = "Clean Code",
                        Author  = "Robert C. Martin",
                        ISBN    = "978-0-13-235088-4",
                        Subject = "CS201"
                    },
                    new Textbook
                    {
                        Title   = "Financial Accounting",
                        Author  = "Walter Harrison",
                        ISBN    = "978-0-13-342842-0",
                        Subject = "ACC101"
                    },
                    new Textbook
                    {
                        Title   = "Business Management",
                        Author  = "Gareth Jones",
                        ISBN    = "978-0-07-353031-2",
                        Subject = "MGT201"
                    },
                    new Textbook
                    {
                        Title   = "Statistics for Business",
                        Author  = "David Anderson",
                        ISBN    = "978-1-305-58520-1",
                        Subject = "STA101"
                    },
                    new Textbook
                    {
                        Title   = "Human Resource Management",
                        Author  = "Gary Dessler",
                        ISBN    = "978-0-13-452679-1",
                        Subject = "HRM301"
                    }
                };

                db.Textbooks.AddRange(textbooks);
                await db.SaveChangesAsync();

                var listings = new List<Listing>
                {
                    new Listing
                    {
                        UserId         = seller.Id,
                        TextbookId     = textbooks[0].TextbookId,
                        Price          = 250,
                        Condition      = "Good",
                        CampusLocation = "Howard College",
                        Status         = "Active",
                        DatePosted     = DateTime.UtcNow.AddDays(-5)
                    },
                    new Listing
                    {
                        UserId         = seller.Id,
                        TextbookId     = textbooks[1].TextbookId,
                        Price          = 180,
                        Condition      = "New",
                        CampusLocation = "Westville",
                        Status         = "Active",
                        DatePosted     = DateTime.UtcNow.AddDays(-3)
                    },
                    new Listing
                    {
                        UserId         = seller.Id,
                        TextbookId     = textbooks[2].TextbookId,
                        Price          = 150,
                        Condition      = "Fair",
                        CampusLocation = "PMB Campus",
                        Status         = "Active",
                        DatePosted     = DateTime.UtcNow.AddDays(-7)
                    },
                    new Listing
                    {
                        UserId         = admin.Id,
                        TextbookId     = textbooks[3].TextbookId,
                        Price          = 200,
                        Condition      = "Good",
                        CampusLocation = "Howard College",
                        Status         = "Active",
                        DatePosted     = DateTime.UtcNow.AddDays(-2)
                    },
                    new Listing
                    {
                        UserId         = admin.Id,
                        TextbookId     = textbooks[4].TextbookId,
                        Price          = 120,
                        Condition      = "Fair",
                        CampusLocation = "Westville",
                        Status         = "Active",
                        DatePosted     = DateTime.UtcNow.AddDays(-1)
                    },
                    new Listing
                    {
                        UserId         = seller.Id,
                        TextbookId     = textbooks[5].TextbookId,
                        Price          = 300,
                        Condition      = "New",
                        CampusLocation = "PMB Campus",
                        Status         = "Active",
                        DatePosted     = DateTime.UtcNow
                    }
                };

                db.Listings.AddRange(listings);
                await db.SaveChangesAsync();
            }

            // ── Seed Wanted Ads ───────────────────────────────────────
            if (!db.WantedAds.Any())
            {
                var wantedAds = new List<WantedAd>
                {
                    new WantedAd
                    {
                        UserId     = buyer.Id,
                        Title      = "Programming in C#",
                        Author     = "Any Author",
                        Subject    = "CS101",
                        MaxPrice   = 200,
                        Campus     = "Howard College",
                        DatePosted = DateTime.UtcNow.AddDays(-1),
                        IsActive   = true
                    },
                    new WantedAd
                    {
                        UserId     = buyer.Id,
                        Title      = "Principles of Marketing",
                        Author     = "Philip Kotler",
                        Subject    = "MKT201",
                        MaxPrice   = 150,
                        Campus     = "Westville",
                        DatePosted = DateTime.UtcNow,
                        IsActive   = true
                    }
                };

                db.WantedAds.AddRange(wantedAds);
                await db.SaveChangesAsync();
            }
        }
    }
} 
