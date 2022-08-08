using Diff.WebUI.Models.DataContexts;
using Diff.WebUI.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Diff.WebUI.AppCode.Modules.ContactPostModule
{
    public class ContactPostsAllQuery : IRequest<IEnumerable<ContactPost>>
    {
        public class ContactPostsAllQueryHandler : IRequestHandler<ContactPostsAllQuery, IEnumerable<ContactPost>>
        {
            readonly DiffDbContext db;
            public ContactPostsAllQueryHandler(DiffDbContext db)
            {
                this.db = db;
            }

            public async Task<IEnumerable<ContactPost>> Handle(ContactPostsAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.ContactPosts
                    .ToListAsync(cancellationToken);
                return data;
            }
        }
    }
}