using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SomaAfrica.Data;
using SomaAfrica.Models;

namespace SomaAfrica.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Textbook> Textbooks { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<WantedAd> WantedAds { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Listing → User
            builder.Entity<Listing>()
                .HasOne(l => l.User)
                .WithMany()
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Listing → Textbook
            builder.Entity<Listing>()
                .HasOne(l => l.Textbook)
                .WithMany(t => t.Listings)
                .HasForeignKey(l => l.TextbookId)
                .OnDelete(DeleteBehavior.Cascade);

            // Offer → Listing
            builder.Entity<Offer>()
                .HasOne(o => o.Listing)
                .WithMany()
                .HasForeignKey(o => o.ListingId)
                .OnDelete(DeleteBehavior.Cascade);

            // Offer → Buyer (User)
            builder.Entity<Offer>()
                .HasOne(o => o.Buyer)
                .WithMany()
                .HasForeignKey(o => o.BuyerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Transaction → Offer
            builder.Entity<Transaction>()
                .HasOne(t => t.Offer)
                .WithMany()
                .HasForeignKey(t => t.OfferId)
                .OnDelete(DeleteBehavior.Restrict);

            // Review → Transaction
            builder.Entity<Review>()
                .HasOne(r => r.Transaction)
                .WithMany()
                .HasForeignKey(r => r.TransactionId)
                .OnDelete(DeleteBehavior.Restrict);

            // WantedAd → User
            builder.Entity<WantedAd>()
                .HasOne(w => w.User)
                .WithMany()
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Decimal precision — prevents SQL Server truncation warnings
            builder.Entity<Listing>()
                .Property(l => l.Price)
                .HasColumnType("decimal(18,2)");

            builder.Entity<Offer>()
                .Property(o => o.ProposedPrice)
                .HasColumnType("decimal(18,2)");

            builder.Entity<WantedAd>()
                .Property(w => w.MaxPrice)
                .HasColumnType("decimal(18,2)");

            builder.Entity<ApplicationUser>()
                .Property(u => u.TrustScore)
                .HasColumnType("decimal(18,2)");

            // Indexes for faster searching
            builder.Entity<Textbook>()
                .HasIndex(t => t.ISBN);
            builder.Entity<Textbook>()
                .HasIndex(t => t.Title);
            builder.Entity<Listing>()
                .HasIndex(l => l.Status);
            builder.Entity<Listing>()
                .HasIndex(l => l.CampusLocation);
        }
    }
}