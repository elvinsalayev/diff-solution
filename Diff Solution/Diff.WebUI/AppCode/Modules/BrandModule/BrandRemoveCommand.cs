using Diff.WebUI.AppCode.Infrastructure;
using Diff.WebUI.Models.DataContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Diff.WebUI.AppCode.Modules.BrandModule
{
    public class BrandRemoveCommand : IJsonRequest
    {
            public int Id { get; set; }
        public class BrandRemoveCommandHandler : IJsonRequestHandler<BrandRemoveCommand>
        {
            readonly DiffDbContext db;
            public BrandRemoveCommandHandler(DiffDbContext db)
            {
                this.db = db;
            }

            public async Task<CommandJsonResponse> Handle(BrandRemoveCommand request, CancellationToken cancellationToken)
            {
                var entity = await db.Brands
                  .FirstOrDefaultAsync(b => b.Id == request.Id && b.DeletedById == null, cancellationToken);

                if (entity == null)
                {
                    return new CommandJsonResponse(true,"Mövcud deyil.");
                }
                entity.DeletedById = 1;
                entity.DeletedDate = DateTime.UtcNow.AddHours(4);
                await db.SaveChangesAsync(cancellationToken);

                return new CommandJsonResponse(false, "Silindi.");

            }
        }
    }
}
