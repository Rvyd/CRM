using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record UserDto
    {
        //form elemanlarını destekleyecek şekilde klavyeyi gösteririr
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="İsim alanını doldurun")]
        public String? UserName { get; init; }
        [Required(ErrorMessage ="Mail alanını doldurun")]
        [DataType(DataType.EmailAddress)]
        public String? Email { get; init; }
        [DataType(DataType.PhoneNumber)]
        public String? PhoneNumber { get; init; }
        public HashSet<String> Roles { get; set; } = new HashSet<string>();
    }

}