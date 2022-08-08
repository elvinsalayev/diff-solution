using Diff.Core.Extensions;
using Diff.WebUI.AppCode.Extensions;
using Diff.WebUI.AppCode.Infrastructure;
using Diff.WebUI.Models.DataContexts;
using Diff.WebUI.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace Diff.WebUI.AppCode.Modules.SubscribeModule
{
    public class SubscribeCreateCommand : IRequest<CommandJsonResponse>
    {
        [Required(ErrorMessage = "Boş buraxmaq olmaz.")]
        [EmailAddress(ErrorMessage = "Email uyğun deyil.")]
        public string Email { get; set; }

        public class SubscribeCreateCommandHandler : IRequestHandler<SubscribeCreateCommand, CommandJsonResponse>
        {
            readonly DiffDbContext db;
            readonly IConfiguration configuration;
            readonly IActionContextAccessor ctx;
            public SubscribeCreateCommandHandler(DiffDbContext db, IConfiguration configuration, IActionContextAccessor ctx)
            {
                this.db = db;
                this.configuration = configuration;
                this.ctx = ctx;
            }

            public async Task<CommandJsonResponse> Handle(SubscribeCreateCommand request, CancellationToken cancellationToken)

            {
                var subscribe = await db.Subscribes
                    .FirstOrDefaultAsync(s => s.Email.Equals(request.Email), cancellationToken);

                if (subscribe == null)
                {
                    subscribe = new Subscribe();
                    subscribe.Email = request.Email;
                    await db.Subscribes.AddAsync(subscribe, cancellationToken);
                    await db.SaveChangesAsync(cancellationToken);
                }

                else if (subscribe.EmailIsSent == true)
                {
                    return new CommandJsonResponse
                    {
                        Error = true,
                        Message = "Bu email artıq istifadə olunub."
                    };
                }


                string token = $"{subscribe.Id}-{subscribe.Email}".Encrypt();
                string link = $"{ctx.GetAppLink()}/subscribe-confirm?token={token}";

                var emailSuccess = configuration.SendMail(subscribe.Email, "Email Təsdiqləmə", $"Təsdiqləmək üçün linkə keçid edin. <a href=\"{link}\">LINK</a>", cancellationToken);

                if (emailSuccess == true)
                {

                    subscribe.EmailIsSent = true;

                    await db.SaveChangesAsync(cancellationToken);
                }
                else
                {
                    return new CommandJsonResponse
                    {
                        Error = true,
                        Message = "Xəta baş verdi, bir az sonra yenidən yoxlayın."
                    };
                }



                return new CommandJsonResponse
                {
                    Error = false,
                    Message = $"Tamamlamaq üçün \"{subscribe.Email}\" emailinə göndərilmiş linkə keçid edin."
                };
            }
        }
    }

}

