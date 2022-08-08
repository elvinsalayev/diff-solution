using Diff.WebUI.AppCode.Infrastructure;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diff.WebUI.Models.Entities
{
    public class Category : BaseEntity
    {
        [Display(Name = "Kateqoriyanın Adı:")]
        [Required(ErrorMessage = "Boş buraxmaq olmaz.")]
        public string Name { get; set; }
        [Display(Name = "Üst kateqoriyanın Adı:")]
        public int? ParentId { get; set; }
        public virtual Category Parent { get; set; }
        public virtual ICollection<Category> Children { get; set; }
        [NotMapped]
        public string ParentName { get; set; }
        public virtual ICollection<Blogpost> Blogposts { get; set; }    
    }
}
