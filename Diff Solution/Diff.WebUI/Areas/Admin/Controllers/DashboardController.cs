using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diff.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        
        [Authorize("admin.dashboard.index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
