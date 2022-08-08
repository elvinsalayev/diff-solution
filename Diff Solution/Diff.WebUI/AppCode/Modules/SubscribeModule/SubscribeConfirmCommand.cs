using Diff.Core.Extensions;
using Diff.WebUI.AppCode.Extensions;
using Diff.WebUI.AppCode.Infrastructure;
using Diff.WebUI.Models.DataContexts;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Diff.WebUI.AppCode.Modules.SubscribeModule
{
    public class SubscribeConfirmCommand : IRequest<CommandJsonResponse>
    {

        public string Token { get; set; }
        public class SubscribeConfirmCommandHandler : IRequestHandler<SubscribeConfirmCommand, CommandJsonResponse>
        {
            readonly DiffDbContext db;
            readonly IActionContextAccessor ctx;
            public SubscribeConfirmCommandHandler(DiffDbContext db, IActionContextAccessor ctx)
            {
                this.db = db;
                this.ctx = ctx;
            }
            public async Task<CommandJsonResponse> Handle(SubscribeConfirmCommand request, CancellationToken cancellationToken)
            {
                if (string.IsNullOrWhiteSpace(request.Token))
                {
                    ctx.AddModelError("Token", "Token boşdur.");
                    goto l1;
                }

                request.Token = request.Token.Decrypt();
                Match match = Regex.Match(request.Token, @"subscribetoken-(?<id>\d+)-(?<email>^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$)"); //(?<executeTimeStamp>\d{14})
                if (!match.Success)
                {
                    ctx.AddModelError("Token", "Token zədələnmişdir.");
                    goto l1;
                }
                int id = Convert.ToInt32(match.Groups["id"].Value);
                string email = match.Groups["email"].Value;

                var subscribe = await db.Subscribes
                    .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
                if (subscribe == null)
                {
                    ctx.AddModelError("Token", "Tapılmadı.");
                    goto l1;
                }
                else if (!email.Equals(subscribe.Email))
                {
                    ctx.AddModelError("Token", "Token düzgün deyil.");
                    goto l1;
                }

                subscribe.AppliedDate = DateTime.UtcNow.AddHours(4);

                await db.SaveChangesAsync(cancellationToken);
                return new CommandJsonResponse(false, "Uğurla tamamlandı.");


            l1:
                return new CommandJsonResponse(true, ctx.GetError());
            }

        }
    }
}
