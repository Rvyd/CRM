using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record UserDtoForCreation: UserDto
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Şifre alanını doldurun")]
        public String? Password { get; init; }
    }
}