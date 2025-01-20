using System.ComponentModel.DataAnnotations;

namespace TradeList.Models
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength (100)]
        public required string Name { get; set; }


        [EmailAddress]
        public required string Email { get; set; }


        [MinLength(6)] 
        public required string Password { get; set; }

        
    }
}
