using System.ComponentModel.DataAnnotations;

namespace Diff.WebUI.Models.FormModels
{
    public class ChangePasswordFormModel
    {
        [Required, DataType(DataType.Password), Display(Name = "Şifrə")]
        public string CurrentPassword { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "Yeni şifrə")]
        public string NewPassword { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "Şifrəni təsdiqlə")]
        [Compare("NewPassword",ErrorMessage ="Şifrələr eyni deyil.")]
        public string ConfirmPassword { get; set; }
    }
}
