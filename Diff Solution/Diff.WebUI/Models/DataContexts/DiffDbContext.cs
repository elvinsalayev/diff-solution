using Diff.WebUI.Models.Entities;
using Diff.WebUI.Models.Entities.Membership;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Diff.WebUI.Models.DataContexts
{
    public class DiffDbContext : IdentityDbContext<DiffUser,
        DiffRole,
        int,
        DiffUserClaim,
        DiffUserRole,
        DiffUserLogin,
        DiffRoleClaim,
        DiffUserToken>
    {
        public DiffDbContext(DbContextOptions options)
        : base(options)
        {

        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Blogpost> Blogposts { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<BlogPostTag> BlogPostTagClouds { get; set; }
        public DbSet<ContactPost> ContactPosts { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductSpecification> ProductSpecifications { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductPricing> ProductPricing { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BlogPostTag>(e =>
            {
                e.HasKey(k => new { k.BlogPostId, k.PostTagId });
            });

            modelBuilder.Entity<ProductSpecification>(e =>
            {
                e.HasKey(k => new { k.ProductId, k.SpecificationId });
            });

            modelBuilder.Entity<ProductPricing>(e =>
            {
                e.HasKey(k => new { k.ProductId, k.ProductColorId, k.ProductSizeId });
            });

            modelBuilder.Entity<DiffUser>(e =>
            {
                e.ToTable("Users", "Membership");
            });

            modelBuilder.Entity<DiffRole>(e =>
            {
                e.ToTable("Roles", "Membership");
            });

            modelBuilder.Entity<DiffUserClaim>(e =>
            {
                e.ToTable("UserClaims", "Membership");
            });

            modelBuilder.Entity<DiffUserToken>(e =>
            {

                e.HasKey(k => new
                {
                    k.UserId,
                    k.LoginProvider,
                    k.Name
                });
                e.ToTable("UserTokens", "Membership");
            });

            modelBuilder.Entity<DiffUserLogin>(e =>
            {
                e.HasKey(k => new
                {
                    k.UserId,
                    k.LoginProvider,
                    k.ProviderKey
                });
                e.ToTable("UserLogins", "Membership");
            });

            modelBuilder.Entity<DiffRoleClaim>(e =>
            {
                e.ToTable("RoleClaims", "Membership");
            });

            modelBuilder.Entity<DiffUserRole>(e =>
            {

                e.HasKey(k => new
                {
                    k.UserId,
                    k.RoleId
                });
                e.ToTable("UserRoles", "Membership");
            });

        }
    }
}
