using Diff.WebUI.Models.DataContexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Diff.WebUI.Controllers
{
    [AllowAnonymous]
    public class FaqController : Controller
    {
        readonly DiffDbContext db;
        public FaqController(DiffDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var faqs = db.Faqs.ToList();
            return View(faqs);
        }
    }
}
