using Diff.WebUI.AppCode.Infrastructure;

namespace Diff.WebUI.Models.Entities
{
    public class ProductColor : BaseEntity
    {
        public string Name { get; set; }
         
        public string HexCode { get; set; }
    }
}
