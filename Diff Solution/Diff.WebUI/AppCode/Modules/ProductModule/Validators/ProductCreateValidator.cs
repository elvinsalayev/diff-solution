using FluentValidation;

namespace Diff.WebUI.AppCode.Modules.ProductModule.Validators
{
    public class ProductCreateValidator : AbstractValidator<ProductCreateCommand>
    {
        public ProductCreateValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Boş buraxıla bilməz.");


            RuleFor(p => p.ShortDescription)
                .NotEmpty()
                .NotNull()
                .WithMessage("Boş buraxıla bilməz.");


            RuleFor(p => p.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("Boş buraxıla bilməz.");


            RuleFor(p => p.StockKeepingUnit)
                .NotEmpty()
                .NotNull()
                .WithMessage("Boş buraxıla bilməz.");


            RuleFor(p => p.BrandId).GreaterThan(0).WithMessage("Düzgün ədəd daxil edilməyib.");

            RuleFor(p => p.CategoryId).GreaterThan(0).WithMessage("Düzgün ədəd daxil edilməyib.");

            RuleForEach(p => p.Specification)
                .ChildRules(cp =>
                {
                    cp.RuleFor(cpi => cpi.Value)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Boş buraxıla bilməz.");
                });

        }
    }

}
