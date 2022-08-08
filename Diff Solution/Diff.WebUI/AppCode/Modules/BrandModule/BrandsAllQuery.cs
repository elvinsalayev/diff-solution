using Diff.WebUI.Models.DataContexts;
using Diff.WebUI.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Diff.WebUI.AppCode.Modules.BrandModule
{
    public class BrandsAllQuery : IRequest<IEnumerable<Brand>>
    {
        public class BrandsAllQueryHandler : IRequestHandler<BrandsAllQuery, IEnumerable<Brand>>
        {
            readonly DiffDbContext db;
            public BrandsAllQueryHandler(DiffDbContext db)
            {
                this.db = db;
            }
            public async Task<IEnumerable<Brand>> Handle(BrandsAllQuery request, CancellationToken cancellationToken)
            {
                var model = await db.Brands
                    .Where(b => b.DeletedById == null)
                    .ToListAsync(cancellationToken);
                return model;
            }
        }
    }
}
