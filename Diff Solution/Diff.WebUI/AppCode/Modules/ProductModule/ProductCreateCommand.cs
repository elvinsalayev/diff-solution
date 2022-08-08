using Diff.WebUI.AppCode.Extensions;
using Diff.WebUI.Models.DataContexts;
using Diff.WebUI.Models.Entities;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ok = Diff.WebUI.Models.Entities;

namespace Diff.WebUI.AppCode.Modules.ProductModule
{
    public class ProductCreateCommand : IRequest<ProductCreateCommandResponse>
    {
        public string Name { get; set; }
        public string StockKeepingUnit { get; set; }
        public int BrandId { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public SpecificationKeyValue[] Specification { get; set; }
        public ProductPricing[] Pricing { get; set; }
        public ImageItem[] Images { get; set; }

        public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, ProductCreateCommandResponse>
        {
            readonly DiffDbContext db;
            readonly IActionContextAccessor ctx;
            readonly IWebHostEnvironment env;
            readonly IValidator<ProductCreateCommand> validator;
            public ProductCreateCommandHandler(DiffDbContext db, IActionContextAccessor ctx, IWebHostEnvironment env, IValidator<ProductCreateCommand> validator)
            {
                this.db = db;
                this.ctx = ctx;
                this.env = env;
                this.validator = validator;
            }

            public async Task<ProductCreateCommandResponse> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
            {
                var result = validator.Validate(request);


                if (!result.IsValid)
                {
                    var response = new ProductCreateCommandResponse
                    {
                        Product = null,
                        ValidationResult = result
                    };
                    return response;
                }


                var product = new Product();
                product.Name = request.Name;
                product.StockKeepingUnit = request.StockKeepingUnit;
                product.BrandId = request.BrandId;
                product.CategoryId = request.CategoryId;
                product.ShortDescription = request.ShortDescription;
                product.Description = request.Description;


                if (request.Specification != null && request.Specification.Length > 0)
                {
                    product.Specifications = new List<ProductSpecification>();

                    foreach (var specification in request.Specification)
                    {
                        product.Specifications.Add(new ProductSpecification()
                        {
                            SpecificationId = specification.Id,
                            Value = specification.Value
                        });
                    }
                }


                if (request.Images != null && request.Images.Any(i => i.File != null))
                {
                    product.Images = new List<ProductImage>();

                    foreach (var image in request.Images.Where(i => i.File != null))
                    {
                        string name = await env.SaveFile(image.File, cancellationToken, "product");
                        product.Images.Add(new ProductImage()
                        {
                            ImagePath = name,
                            IsMain = image.IsMain
                        });
                    }
                }
                else
                {
                    ctx.AddModelError("Images", "Şəkil qeyd edilməyib");
                    goto l1;
                }


                if (request.Pricing != null && request.Pricing.Length > 0)
                {
                    product.Pricing = new List<ok.ProductPricing>();
                    foreach (var pricing in request.Pricing)
                    {
                        product.Pricing.Add(new ok.ProductPricing()
                        {
                            ProductColorId = pricing.ProductColorId,
                            ProductSizeId = pricing.ProductSizeId,
                            Price = pricing.Price
                        });
                    }
                }

                await db.Products.AddAsync(product, cancellationToken);

                try
                {
                    await db.SaveChangesAsync(cancellationToken);

                    var response = new ProductCreateCommandResponse
                    {
                        Product = null,
                        ValidationResult = result
                    };
                    return response;
                }
                catch (System.Exception)
                {
                    var response = new ProductCreateCommandResponse
                    {
                        Product = null,
                        ValidationResult = result
                    };

                    response.ValidationResult.Errors.Add(new ValidationFailure("Name", "Xəta baş verdi, yenidən yoxlayın."));

                    return response;
                }

            l1:
                return null;

            }
        }
    }

    public class ProductCreateCommandResponse
    {
        public Product Product { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }


}
