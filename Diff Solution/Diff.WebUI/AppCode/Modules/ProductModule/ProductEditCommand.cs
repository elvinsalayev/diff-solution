using Diff.WebUI.AppCode.Extensions;
using Diff.WebUI.Models.DataContexts;
using Diff.WebUI.Models.Entities;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Diff.WebUI.AppCode.Modules.ProductModule
{
    public class ProductEditCommand : IRequest<ProductEditCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StockKeepingUnit { get; set; }
        public int BrandId { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public SpecificationKeyValue[] Specification { get; set; }
        public ProductPricing[] Pricing { get; set; }
        public ImageItem[] Images { get; set; }


        public class ProductEditCommandHandler : IRequestHandler<ProductEditCommand, ProductEditCommandResponse>
        {
            readonly DiffDbContext db;
            readonly IActionContextAccessor ctx;
            readonly IWebHostEnvironment env;
            readonly IValidator<ProductEditCommand> validator;
            
            public ProductEditCommandHandler(DiffDbContext db, 
                IActionContextAccessor ctx, 
                IWebHostEnvironment env, 
                IValidator<ProductEditCommand> validator)
            {
                this.db = db;
                this.ctx = ctx;
                this.env = env;
                this.validator = validator;
            }

            public async Task<ProductEditCommandResponse> Handle(ProductEditCommand request, CancellationToken cancellationToken)
            {
                var result = validator.Validate(request);

                var response = new ProductEditCommandResponse
                {
                    Product = null,
                    ValidationResult = null
                };


                if (!result.IsValid)
                {
                    response.ValidationResult = result;

                    return response;
                }

                var product = await db.Products
                    .Include(p => p.Images)
                    .Include(p => p.Specifications)
                    .Include(p => p.Pricing)
                    .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

                if (product == null)
                {
                    response.ValidationResult.Errors.Add(new ValidationFailure("Name", "Məhsul tapılmadı."));
                    return response;
                }

                product.Name = request.Name;
                product.StockKeepingUnit = request.StockKeepingUnit;
                product.BrandId = request.BrandId;
                product.CategoryId = request.CategoryId;
                product.ShortDescription = request.ShortDescription;
                product.Description = request.Description;

                if (request.Images != null)
                {
                    if (product.Images == null)
                    {
                        product.Images = new List<ProductImage>();
                    }

                    foreach (var image in request.Images)
                    {
                        if (image.File == null && string.IsNullOrWhiteSpace(image.TempPath))
                        {
                            var dbProductImage = product.Images.FirstOrDefault(pi => pi.Id == image.Id);
                            if (dbProductImage!=null)
                            {
                                dbProductImage.DeletedDate = DateTime.UtcNow.AddHours(4);
                                dbProductImage.DeletedById = 1;
                                dbProductImage.IsMain = false;
                            }
                        }
                        else if (image.File != null)
                        {
                            string name = await env.SaveFile(image.File, cancellationToken, "product");
                            product.Images.Add(new ProductImage()
                            {
                                ImagePath = name,
                                IsMain = image.IsMain
                            });
                        }
                        else if (!string.IsNullOrWhiteSpace(image.TempPath))
                        {
                            var dbProductImage = product.Images.FirstOrDefault(pi => pi.Id == image.Id);
                            if (dbProductImage != null)
                            {
                                dbProductImage.IsMain = image.IsMain;
                            }
                        }
                    }
                }
                else
                {
                    ctx.AddModelError("Images", "Şəkil qeyd edilməyib");
                    goto l1;
                }

                if (request.Specification != null && request.Specification.Length > 0)
                {
                    if (product.Specifications == null)
                    {
                        product.Specifications = new List<ProductSpecification>();
                    }

                    foreach (var spec in product.Specifications)
                    {
                        var specFromForm = request.Specification.FirstOrDefault(s => s.Id == spec.SpecificationId);

                        if (specFromForm == null || string.IsNullOrWhiteSpace(specFromForm.Value))
                        {
                            db.ProductSpecifications.Remove(spec);
                        }
                        else
                        {
                            spec.Value = specFromForm.Value;
                        }

                    }

                    var ids = request.Specification.Select(s => s.Id)
                                         .Except(product.Specifications.Select(s => s.SpecificationId));

                        foreach (var id in ids)
                        {
                            var newSpecs = request.Specification.FirstOrDefault(s => s.Id == id);

                            product.Specifications.Add(new ProductSpecification
                            {
                                SpecificationId = newSpecs.Id,
                                Value = newSpecs.Value
                            });
                        }
                    }
                





                //if (request.Pricing != null && request.Pricing.Length > 0)
                //{
                //    product.Pricing = new List<ok.ProductPricing>();
                //    foreach (var pricing in request.Pricing)
                //    {
                //        product.Pricing.Add(new ok.ProductPricing()
                //        {
                //            ProductColorId = pricing.ProductColorId,
                //            ProductSizeId = pricing.ProductSizeId,
                //            Price = pricing.Price
                //        });
                //    }
                //}

                //await db.Products.AddAsync(product, cancellationToken);

                try
                {
                    await db.SaveChangesAsync(cancellationToken);
                    response.Product = product;
                    response.ValidationResult = result;


                    return response;
                }
                catch (Exception ex)
                {
                    response.Product = product;
                    response.ValidationResult = result;

                    response.ValidationResult.Errors.Add(new ValidationFailure("Name", "Xəta baş verdi, yenidən yoxlayın."));

                    return response;
                }

            l1:
                return null;

            }
        }
    }

    public class ProductEditCommandResponse
    {
        public Product Product { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }


}
