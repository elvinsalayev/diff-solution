using Diff.WebUI.AppCode.Infrastructure;
using System.Collections.Generic;

namespace Diff.WebUI.Models.Entities
{
    public class Specification : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<ProductSpecification> Specifications { get; set; }
    }
}
