using Microsoft.AspNetCore.Identity;

namespace TradeList.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Dodaj właściwość FullName
        public string FullName { get; set; }
    }
}
