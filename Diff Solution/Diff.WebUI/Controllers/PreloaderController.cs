using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diff.WebUI.Controllers
{
    [AllowAnonymous]
    public class PreloaderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
