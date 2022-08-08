using Diff.WebUI.AppCode.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace Diff.WebUI.Models.Entities
{
    public class Brand : BaseEntity
    {

        [Display(Name="Brendin Adı:")]
        [Required(ErrorMessage="Boş buraxmaq olmaz.")]
        public string Name { get; set; }
    }
}
