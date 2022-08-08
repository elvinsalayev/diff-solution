using Diff.WebUI.AppCode.Infrastructure;

namespace Diff.WebUI.Models.Entities
{
    public class Faq : BaseEntity
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
