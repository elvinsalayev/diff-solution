using Diff.WebUI.AppCode.Modules.AccountModule;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Diff.WebUI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        readonly IMediator mediator;
        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [AllowAnonymous]
        [Route("/signin.html")]
        public IActionResult Signin()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("/signin.html")]
        public async Task<IActionResult> Signin(SigninCommand command)
        {

            var response = await mediator.Send(command);

            if (!ModelState.IsValid)
            {
                return View(command);

            }

            return RedirectToAction("Index", "Home");
        }
    }
}
