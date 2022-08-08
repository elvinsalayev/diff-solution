using Diff.WebUI.Models.DataContexts;
using Diff.WebUI.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Diff.WebUI.AppCode.Modules.BrandModule
{
    public class BrandCreateCommand : IRequest<Brand>
    {
        public string Name { get; set; }

        public class BrandCreateCommandHandler : IRequestHandler<BrandCreateCommand, Brand>
        {
            readonly DiffDbContext db;
            public BrandCreateCommandHandler(DiffDbContext db)
            {
                this.db = db;
            }

            public async Task<Brand> Handle(BrandCreateCommand request, CancellationToken cancellationToken)
            {
                var brand = new Brand();
                brand.Name = request.Name;

                await db.Brands.AddAsync(brand, cancellationToken);

                await db.SaveChangesAsync(cancellationToken);

                return brand;
            }
        }
    }
}
