using Diff.WebUI.AppCode.Extensions;
using Diff.WebUI.AppCode.Modules.ProfileModule;
using Diff.WebUI.Models.DataContexts;
using Diff.WebUI.Models.Entities.Membership;
using Diff.WebUI.Models.FormModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Diff.WebUI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly DiffDbContext db;
        private readonly SignInManager<DiffUser> signInManager;
        private readonly UserManager<DiffUser> userManager;
        private readonly IConfiguration configuration;
        private readonly IActionContextAccessor ctx;
        private readonly IMediator mediator;

        public AccountController(DiffDbContext db, SignInManager<DiffUser> signInManager, UserManager<DiffUser> userManager,
            IConfiguration configuration,
            IActionContextAccessor ctx, IMediator mediator)
        {
            this.db = db;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.configuration = configuration;
            this.ctx = ctx;
            this.mediator = mediator;
        }
        [Route("/signin.html")]
        [AllowAnonymous]
        public IActionResult SignIn()
        {
            return View();
        }
        [Route("/profile.html")]
        public async Task<IActionResult> Profile()
        {
            var userId = User.GetUserId();
            var user = await userManager.FindByIdAsync(userId);
            var command = new ProfileEditCommand();
            command.Id = user.Id;
            command.Name = user.Name;
            command.Surname = user.Surname;
            command.Username = user.UserName;
            command.Email = user.Email;
            command.EmailConfirmed = user.EmailConfirmed;
            command.ImagePath = user.ImagePath;
            return View(command);
        }

        [HttpPost]
        [Route("/profile.html")]
        public async Task<IActionResult> Profile(ProfileEditCommand command)
        {
            if (ModelState.IsValid)
            {
                var userId = User.GetUserId();
                command.Id = Convert.ToInt32(userId);
                var response = await mediator.Send(command);
                return RedirectToAction(nameof(Profile));
            }

            return View(command);
        }
        [Route("/accessdenied.html")]
        public IActionResult AccessDenied()
        {
            return View();
        }
        [Route("/logout.html")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(SignIn));
        }
        [HttpPost]
        [Route("/signin.html")]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(LoginFormModel user)
        {
            if (ModelState.IsValid)
            {
                DiffUser foundedUser = null;

                if (user.UserName.IsEmail())
                {
                    foundedUser = await userManager.FindByEmailAsync(user.UserName);
                }
                else
                {
                    foundedUser = await userManager.FindByNameAsync(user.UserName);
                }


                if (foundedUser == null)
                {
                    ViewBag.Message = "E-Poçtunuz və ya şifrəniz yanlışdır!";
                    goto end;
                }
                var signInResult = await signInManager.PasswordSignInAsync(foundedUser, user.Password, true, true);

                if (!signInResult.Succeeded)
                {
                    ViewBag.Message = "E-Poçtunuz və ya şifrəniz yanlışdır!";
                    goto end;
                }

                var callBackUrl = Request.Query["ReturnUrl"];

                if (!string.IsNullOrWhiteSpace(callBackUrl))
                {
                    return Redirect(callBackUrl);
                }
                return RedirectToAction("Index", "Home");
            }

        end:
            return View(user);
        }
        [AllowAnonymous]
        [Route("/register.html")]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [Route("/register.html")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new DiffUser();
                user.Email = model.Email;
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.UserName = model.Username;
                user.ImagePath = "profile-photo.jpg";

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    string path = $"{ctx.GetAppLink()}/registration-confirm.html?email={user.Email}&token={token}";
                    var emailResponse = configuration.SendEmail(user.Email, "Diff istifadəçi qeydiyyatı", $"Zəhmət olmasa <a href=\"{path}\">link</a> linkə keçid edib qeydiyyatı tamamlayın.");
                    if (emailResponse)
                    {
                        ViewBag.Message = "Qeydiyyat tamamlandı, sizinlə tezliklə əlaqə saxlanılacaq";
                    }
                    else
                    {
                        ViewBag.Message = "Səhv oldu, yenidən cəhd edin.";
                    }

                    return RedirectToAction(nameof(SignIn));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
            }
            return View(model);
        }
        [HttpGet]
        [Route("/registration-confirm.html")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterConfirm(string email, string token)
        {
            var foundedUser = await userManager.FindByEmailAsync(email);
            if (foundedUser == null)
            {
                ViewBag.Message = "Xətalı token göndərilib.";
                goto end;
            }
            token = token.Replace(" ", "+");
            var result = await userManager.ConfirmEmailAsync(foundedUser, token);
            if (!result.Succeeded)
            {
                ViewBag.Message = "Xətalı token göndərilib.";
                goto end;
            }
            ViewBag.Message = "Hesabınız təsdiqləndi, sizinlə tezliklə əlaqə saxlanılacaq.";
        end:
            return RedirectToAction(nameof(SignIn));
        }




    }
}
