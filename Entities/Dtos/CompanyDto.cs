using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record CompanyDto
    {
        public int CompanyId { get; set; }
    [Required(ErrorMessage ="İsim alanını doldurunuz!")]
    public String? CompanyName { get; set; } = String.Empty;
    [Required(ErrorMessage ="Adres alanını doldurunuz!")]
    public String? CompanyAddress { get; set; } = String.Empty;
    [Required(ErrorMessage ="Telefon numarası alanını doldurunuz!")]
    public String? CompanyPhone { get; set; } = String.Empty;
   
    public String? CompanyLogoUrl { get; set; } = String.Empty;
    public String? CompanyWebSite{get;set;}=String.Empty;

     
    }
}