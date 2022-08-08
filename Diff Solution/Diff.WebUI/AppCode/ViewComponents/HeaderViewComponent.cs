using Diff.WebUI.Models.DataContexts;
using Microsoft.AspNetCore.Mvc;

namespace Diff.WebUI.AppCode.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        readonly DiffDbContext db;
        public HeaderViewComponent( DiffDbContext db)
        {
            this.db = db;

        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
