using Diff.WebUI.AppCode.Modules.SubscribeModule;
using Diff.WebUI.Models.DataContexts;
using Diff.WebUI.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Diff.WebUI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        readonly DiffDbContext db;
        readonly IMediator mediator;
        public HomeController(DiffDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        //[ActionName("Contact")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(ContactPost model)
        {
            if (!ModelState.IsValid)
            {

                return Json(new
                {
                    error = true,
                    message = ModelState.SelectMany(ms => ms.Value.Errors).First().ErrorMessage
                });
            }

            await db.ContactPosts.AddAsync(model);
            await db.SaveChangesAsync();



            return Json(new
            {
                error = false,
                message = "Müraciətiniz qeydə alındı. 3 iş günü ərzində cavablandırılacaq."
            });

        }


        [HttpPost]
        public async Task<IActionResult> Subscribe(SubscribeCreateCommand command)
        {
            var response = await mediator.Send(command);
            return Json(response);
        }

        [HttpGet]
        [Route("/subscribe-confirm")]
        public async Task<IActionResult> SubscribeConfirm(SubscribeConfirmCommand command)
        {
            var response = await mediator.Send(command);
            return View(response);
        }


    }
}
