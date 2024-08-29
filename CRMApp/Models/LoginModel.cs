using System.ComponentModel.DataAnnotations;

namespace CRMApp.Models
{
    public class LoginModel
    {
        private string? _returnurl;
        [Required(ErrorMessage ="İsim alanını doldurunuz.")]
        public string? Name { get; set; }
        [Required(ErrorMessage ="Şifre alanını doldurunuz.")]
        public string? Password { get; set; }

        public string Returnurl
        {
            get
            {
                if(_returnurl is null)
                 return "/";
                 else
                  return _returnurl;
            }
            set
            {
                _returnurl=value;
            }
        }
    }
}