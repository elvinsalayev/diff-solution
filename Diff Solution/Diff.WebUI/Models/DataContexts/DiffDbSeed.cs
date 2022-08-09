using Diff.WebUI.Models.Entities;
using Diff.WebUI.Models.Entities.Membership;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Diff.WebUI.Models.DataContexts

{
    public static class DiffDbSeed
    {
        //static internal IApplicationBuilder InitMembership(this IApplicationBuilder app)
        //{
        //    using (IServiceScope scope = app.ApplicationServices.CreateScope())
        //    {
        //        var userManager = scope.ServiceProvider.GetService<UserManager<DiffUser>>();
        //        var roleManager = scope.ServiceProvider.GetService<RoleManager<DiffRole>>();
        //        var configuration = scope.ServiceProvider.GetService<IConfiguration>();

        //        var user = userManager.FindByEmailAsync(configuration["membership:superadmin"]).Result;


        //        if (user == null)
        //        {
        //            user = new DiffUser
        //            {
        //                Email = configuration["membership:superAdmin"],
        //                UserName = configuration["membership:superAdmin"],
        //                EmailConfirmed = true
        //            };

        //            var identityResult = userManager.CreateAsync(user, configuration["membership:password"]).Result;

        //            if (!identityResult.Succeeded)
        //                return app;
        //        }


        //        var roles = configuration["membership:roles"].Split(",", StringSplitOptions.RemoveEmptyEntries);


        //        foreach (var roleName in roles)
        //        {
        //            var role = roleManager.FindByNameAsync(roleName).Result;

        //            if (role == null)
        //            {
        //                role = new DiffRole
        //                {
        //                    Name = roleName
        //                };


        //                var roleResult = roleManager.CreateAsync(role).Result;

        //                if (roleResult.Succeeded)
        //                {
        //                    userManager.AddToRoleAsync(user, roleName).Wait();
        //                }
        //            }
        //            else if (!userManager.IsInRoleAsync(user, roleName).Result)
        //            {
        //                userManager.AddToRoleAsync(user, roleName).Wait();
        //            }
        //        }
        //    }

        //    return app;
        //}



        static internal IApplicationBuilder InitDb(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<DiffDbContext>();

                db.Database.Migrate();

                InitBrands(db);
                InitPostTags(db);
            }
            return app;
        }

        private static void InitPostTags(DiffDbContext db)
        {
            if (!db.PostTags.Any())
            {
                db.PostTags.AddRange(new[]
                {
                    new PostTag{ Name="Diff"},
                    new PostTag{ Name="Marvel"},
                    new PostTag{ Name="DC"},
                    new PostTag{ Name="Stranger Things"},
                    new PostTag{ Name="Mercedes-Benz"},
                    new PostTag{ Name="BMW"},
                    new PostTag{ Name="Porsche"}
                });
                db.SaveChanges();
            }
        }

        private static void InitBrands(DiffDbContext db)
        {
            if (!db.Brands.Any())
            {
                db.Brands.AddRangeAsync(new[]
                {
                    new Brand { Name = "Nike"},
                    new Brand { Name = "Adidas"}
                });
                db.SaveChanges();
            }
        }

    }
}
