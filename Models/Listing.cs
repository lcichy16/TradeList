namespace TradeList.Models
{
    public class Listing
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string UserId { get; set; } // Id użytkownika, który wystawił ogłoszenie
        public ApplicationUser User { get; set; } // Powiązanie z użytkownikiem
    }
}
