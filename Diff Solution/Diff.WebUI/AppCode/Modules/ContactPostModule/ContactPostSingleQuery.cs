using Diff.WebUI.Models.DataContexts;
using Diff.WebUI.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Diff.WebUI.AppCode.Modules.ContactPostModule
{
    public class ContactPostSingleQuery : IRequest<ContactPost>
    {
        public int Id { get; set; }

        public class ContactPostSingleQueryHandler : IRequestHandler<ContactPostSingleQuery, ContactPost>
        {

            readonly DiffDbContext db;
            public ContactPostSingleQueryHandler(DiffDbContext db)
            {
                this.db = db;
            }


            public async Task<ContactPost> Handle(ContactPostSingleQuery request, CancellationToken cancellationToken)
            {
                var model = await db.ContactPosts
                    .FirstOrDefaultAsync(b => b.Id == request.Id, 
                    cancellationToken);

                return model;
            }
        }
    }
}
 