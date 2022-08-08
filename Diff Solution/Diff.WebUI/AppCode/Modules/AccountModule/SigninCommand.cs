using Diff.WebUI.AppCode.Extensions;
using Diff.WebUI.Models.Entities.Membership;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace Diff.WebUI.AppCode.Modules.AccountModule
{
    public class SigninCommand : IRequest<DiffUser>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public class SigninCommandHandler : IRequestHandler<SigninCommand, DiffUser>
        {
            private readonly UserManager<DiffUser> userManager;
            private readonly SignInManager<DiffUser> signInManager;
            private readonly IActionContextAccessor ctx;

            public SigninCommandHandler(UserManager<DiffUser> userManager,
                SignInManager<DiffUser> signInManager, IActionContextAccessor ctx)
            {
                this.userManager = userManager;
                this.signInManager = signInManager;
                this.ctx = ctx;
            }
            public async Task<DiffUser> Handle(SigninCommand request, CancellationToken cancellationToken)
            {
                if (!ctx.ModelIsValid())
                {
                    return null;
                }

                var user = await userManager.FindByEmailAsync(request.UserName);

                if (user == null) 
                {
                    ctx.AddModelError("UserName", "İstifadəçi adı və ya şifrə səhvdir.");
                        return null;
                }

                var signInResult = await signInManager.PasswordSignInAsync(user, request.Password, true,true);


                if (signInResult.IsLockedOut)
                {
                    ctx.AddModelError("UserName", "Hesabınız müvəqqəti olaraq bloklanıb.");
                    return null;
                }

                else if (signInResult.IsNotAllowed)
                {
                    ctx.AddModelError("UserName", "Hesaba giriş hüququnuz məhdudlaşdırılıb.");
                    return null;
                }


                if (!signInResult.Succeeded)
                {
                    ctx.AddModelError("UserName", "İstifadəçi adı və ya şifrə səhvdir.");
                    return null;
                }
                return user;

            }
        }

    }
}
