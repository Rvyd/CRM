using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record ResetDto
    {
        public string? UserName { get; init; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Şifre alanını doldurun")]
        public string? Password { get; init; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        [Required(ErrorMessage ="Şifreyi doğrulayın")]
        public string? ConfirmPassword { get; init; }
    }
}
