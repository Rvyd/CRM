using System.ComponentModel.DataAnnotations;

namespace CRMApp.Areas.Admin.Models
{
    public class RoleModelView
    {
        [Required(ErrorMessage ="İsim alanı zorunludur.")]
        public String RoleName { get; set; }
    }
}