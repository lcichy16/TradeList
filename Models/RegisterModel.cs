using System.ComponentModel.DataAnnotations;

namespace TradeList.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Adres e-mail jest wymagany.")]
        [EmailAddress(ErrorMessage = "Niepoprawny format adresu e-mail.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Pełna nazwa jest wymagana.")]
        public string FullName { get; set; }

        [Compare("Password", ErrorMessage = "Hasła nie pasują do siebie.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
