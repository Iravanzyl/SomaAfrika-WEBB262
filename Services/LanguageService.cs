namespace SomaAfrica.Services
{
    public class LanguageService
    {
        private string _currentLanguage = "en";

        public string CurrentLanguage => _currentLanguage;
        public bool IsZulu => _currentLanguage == "zu";

        public event Action? OnLanguageChanged;

        public void Toggle()
        {
            _currentLanguage = _currentLanguage == "en" ? "zu" : "en";
            OnLanguageChanged?.Invoke();
        }

        public string T(string key) => _currentLanguage == "zu"
            ? _zu.GetValueOrDefault(key, key)
            : _en.GetValueOrDefault(key, key);

        private static readonly Dictionary<string, string> _en = new()
        {
            ["app_name"] = "SomaAfrika",
            ["tagline"] = "Buy & Sell Textbooks on Campus",
            ["home"] = "Home",
            ["listings"] = "Listings",
            ["wanted_ads"] = "Wanted Ads",
            ["dashboard"] = "My Dashboard",
            ["search_placeholder"] = "Search by title, author, ISBN or course code...",
            ["search"] = "Search",
            ["filter"] = "Filter",
            ["sort"] = "Sort",
            ["price"] = "Price",
            ["condition"] = "Condition",
            ["campus"] = "Campus",
            ["min_price"] = "Min Price (R)",
            ["max_price"] = "Max Price (R)",
            ["sort_date"] = "Newest First",
            ["sort_price_asc"] = "Price: Low to High",
            ["sort_price_desc"] = "Price: High to Low",
            ["all_conditions"] = "All Conditions",
            ["new"] = "New",
            ["good"] = "Good",
            ["fair"] = "Fair",
            ["all_campuses"] = "All Campuses",
            ["trust_score"] = "Trust Score",
            ["cash_on_meetup"] = "Cash on Meetup",
            ["my_listings"] = "My Listings",
            ["my_offers"] = "My Offers",
            ["my_transactions"] = "My Transactions",
            ["my_reviews"] = "My Reviews",
            ["completed_transactions"] = "Completed Transactions",
            ["no_listings"] = "No listings found.",
            ["view_listing"] = "View",
            ["make_offer"] = "Make Offer",
            ["login"] = "Login",
            ["register"] = "Register",
            ["logout"] = "Logout",
            ["delete_confirm"] = "Are you sure you want to delete this?",
            ["yes_delete"] = "Yes, Delete",
            ["cancel"] = "Cancel",
            ["success"] = "Success!",
            ["error"] = "Something went wrong.",
            ["page"] = "Page",
            ["of"] = "of",
            ["prev"] = "Previous",
            ["next"] = "Next",
            ["post_wanted_ad"] = "Post Wanted Ad",
            ["add_listing"] = "Add Listing",
            ["title"] = "Title",
            ["author"] = "Author",
            ["isbn"] = "ISBN",
            ["subject"] = "Course / Subject",
            ["meetup_safety"] = "Safety tip: Always meet in a public place on campus.",
        };

        private static readonly Dictionary<string, string> _zu = new()
        {
            ["app_name"] = "SomaAfrika",
            ["tagline"] = "Thenga & Uthengise Izincwadi Ekhempasini",
            ["home"] = "Ikhaya",
            ["listings"] = "Izincwadi Ezithengiswayo",
            ["wanted_ads"] = "Izincwadi Ezifunwayo",
            ["dashboard"] = "Ibhodi Lami",
            ["search_placeholder"] = "Sesha ngesihloko, umbhali, ISBN noma ikhodi yecourse...",
            ["search"] = "Sesha",
            ["filter"] = "Hlunga",
            ["sort"] = "Hlelela",
            ["price"] = "Intengo",
            ["condition"] = "Isimo",
            ["campus"] = "Ikhempasi",
            ["min_price"] = "Intengo Engcono (R)",
            ["max_price"] = "Intengo Ephakeme (R)",
            ["sort_date"] = "Entsha Kuqala",
            ["sort_price_asc"] = "Intengo: Phansi Kuya Phezulu",
            ["sort_price_desc"] = "Intengo: Phezulu Kuya Phansi",
            ["all_conditions"] = "Zonke Izimo",
            ["new"] = "Entsha",
            ["good"] = "Inhle",
            ["fair"] = "Phakathi",
            ["all_campuses"] = "Zonke Izikhungo",
            ["trust_score"] = "Inqolobane Yokwethenjwa",
            ["cash_on_meetup"] = "Ukheshi Ekuhlangananeni",
            ["my_listings"] = "Izincwadi Zami",
            ["my_offers"] = "Iminikelo Yami",
            ["my_transactions"] = "Izintengiselwano Zami",
            ["my_reviews"] = "Izibuyekezo Zami",
            ["completed_transactions"] = "Izintengiselwano Ezifeziwe",
            ["no_listings"] = "Awekho amakheli atholakele.",
            ["view_listing"] = "Buka",
            ["make_offer"] = "Nikela",
            ["login"] = "Ngena",
            ["register"] = "Bhalisa",
            ["logout"] = "Phuma",
            ["delete_confirm"] = "Uqinisekile ukuthi ufuna ukususa lokhu?",
            ["yes_delete"] = "Yebo, Susa",
            ["cancel"] = "Khansela",
            ["success"] = "Kuphumelele!",
            ["error"] = "Kukhona okungahambanga kahle.",
            ["page"] = "Ikhasi",
            ["of"] = "kwa",
            ["prev"] = "Emuva",
            ["next"] = "Phambili",
            ["post_wanted_ad"] = "Thenga Isikhangiso",
            ["add_listing"] = "Engeza Incwadi",
            ["title"] = "Isihloko",
            ["author"] = "Umbhali",
            ["isbn"] = "ISBN",
            ["subject"] = "Ikhosi / Isihloko",
            ["meetup_safety"] = "Iseluleko sokuphepha: Hlangana endaweni yomphakathi ekhempasini.",
        };
    }
} 
