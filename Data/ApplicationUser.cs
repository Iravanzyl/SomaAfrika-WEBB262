using Microsoft.AspNetCore.Identity;

namespace SomaAfrica.Data
{
    public class ApplicationUser : IdentityUser
    {
        // Community Trust Score based on ratings received
        public decimal TrustScore { get; set; } = 0;

        // Language preference for Africanisation toggle
        public string LanguagePreference { get; set; } = "en";
    }
}