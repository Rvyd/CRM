using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record TalkDto
    {
        public int CompanyId { get; set; }

        public String? CompanyName { get; set; }
        public String? CompanyLogoUrl { get; set; }

        public int TalkId { get; set; }
        [Required(ErrorMessage = "İsim alanını doldurunuz!")]
        public String? TalkName { get; set; } = String.Empty;
        [Required(ErrorMessage = "Açıklama alanını doldurunuz!")]
        public String? Explanation { get; set; }
        public String? Employee { get; set; }
 
        public String? State { get; set; }
        [Required(ErrorMessage = "Başlangıç tarihi alanını doldurunuz!")]
        public DateOnly StartDate{ get; set; }
         [Required(ErrorMessage = "Başlangıç saati alanını doldurunuz!")]
        public TimeSpan StartHour { get; set; }
         [Required(ErrorMessage = "Bitiş tarihi alanını doldurunuz!")]
        public DateOnly FinishDate { get; set; }
         [Required(ErrorMessage = "Bitiş saati alanını doldurunuz!")]
        public TimeSpan FinishHour { get; set; }
    }
}