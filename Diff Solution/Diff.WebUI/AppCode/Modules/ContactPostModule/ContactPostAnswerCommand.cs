

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
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Diff.WebUI.AppCode.Modules.ContactPostModule
{
    public class ContactPostAnswerCommand : IRequest<ContactPost>
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Boş buraxıla bilməz.")]
        [MinLength(3, ErrorMessage = "Mesaj 3 simvoldan az ola bilməz.")]
        public string Answer { get; set; }
        public class ContactPostAnswerCommandHandler : IRequestHandler<ContactPostAnswerCommand, ContactPost>
        {
            readonly DiffDbContext db;
            readonly IActionContextAccessor ctx;
            readonly IConfiguration configuration;
            public ContactPostAnswerCommandHandler(DiffDbContext db, IActionContextAccessor ctx, IConfiguration configuration)
            {
                this.db = db;
                this.ctx = ctx;
                this.configuration = configuration;
            }
            public async Task<ContactPost> Handle(ContactPostAnswerCommand request, CancellationToken cancellationToken)
            {
            l1:
                if (!ctx.ModelIsValid())
                {
                    return new ContactPost
                    {
                        Id = request.Id,
                        Answer = request.Answer
                    };
                }

                var post = await db.ContactPosts
                    .FirstOrDefaultAsync(cp => cp.Id == request.Id, cancellationToken);

                if (post == null)
                {
                    ctx.AddModelError("Answer", "Tapılmadı.");
                }
                else if (post.AnswerDate != null)
                {
                    ctx.AddModelError("Answer", "Artıq cavablandırılıb.");
                }
                post.AnswerDate = DateTime.UtcNow.AddHours(4);
                post.Answer = request.Answer;

                StringBuilder sb = new StringBuilder();
                sb.Append("<ul>");
                sb.Append($"<li>{post.Message}</li>");
                sb.Append($"<li>{request.Answer}</li>");
                sb.Append("</ul>");

                var emailSuccess = configuration.SendMail(post.Email,
                    "Cavab mesajı",
                    sb.ToString(),
                    cancellationToken);

                if (emailSuccess == true)
                {
                    await db.SaveChangesAsync(cancellationToken);
                }
                else
                {
                    ctx.AddModelError("Message", "Xəta baş verdi, bir az sonra yenidən yoxlayın.");
                }

                return post;

            }
        }
    }
}
