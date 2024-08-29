using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos;

public record RegisterDto
{
    [Required(ErrorMessage ="İsim alanını doldurunuz!")]
    public String? UserName { get; init; }
    [Required(ErrorMessage ="Mail adres alanını doldurunuz!")]
    public String? Email { get; init; }
    [Required(ErrorMessage ="Şifre alanını doldurunuz!")]

    public String?  PhoneNumber { get; init; }
    public String? Password { get; init; }
   
   
  
}
