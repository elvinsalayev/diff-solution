using Diff.WebUI.AppCode.Extensions;
using Diff.WebUI.Models.DataContexts;
using Diff.WebUI.Models.Entities.Membership;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Diff.WebUI.AppCode.Modules.ProfileModule
{
    public class ProfileEditCommand : IRequest<DiffUser>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string ImagePath { get; set; }
        public IFormFile File { get; set; }

        public class ProfileEditCommandHandler : IRequestHandler<ProfileEditCommand, DiffUser>
        {
            readonly DiffDbContext db;
            readonly IWebHostEnvironment env;
            readonly IActionContextAccessor ctx;

            public ProfileEditCommandHandler(DiffDbContext db, IWebHostEnvironment env, IActionContextAccessor ctx)
            {
                this.db = db;
                this.env = env;
                this.ctx = ctx;
            }

            public async Task<DiffUser> Handle(ProfileEditCommand request, CancellationToken cancellationToken)
            {
                if (ctx.ModelIsValid())
                {
                    if (request.File == null && string.IsNullOrEmpty(request.ImagePath))
                    {
                        ctx.AddModelError("ImagePath", "Şəkil boş ola bilməz.");
                    }
                    var currentEntity = await db.Users
                        .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
                    if (currentEntity == null)
                    {
                        return null;
                    }
                    string oldFileName = request.ImagePath;
                    if (request.File != null)
                    {
                        string fileExtension = Path.GetExtension(request.File.FileName);
                        string name = $"user-{Guid.NewGuid()}{fileExtension}";
                        string physicalPath = Path.Combine(env.ContentRootPath, "wwwroot", "uploads", "images", "users", name);
                        using (var fs = new FileStream(physicalPath, FileMode.Create, FileAccess.Write))
                        {
                            request.File.CopyTo(fs);
                        }
                        currentEntity.ImagePath = name;
                        string oldPhysicalPath = Path.Combine(env.ContentRootPath, "wwwroot", "uploads", "images", "users", oldFileName);
                        if (System.IO.File.Exists(oldPhysicalPath))
                        {
                            System.IO.File.Delete(oldPhysicalPath);
                        }
                    }
                    currentEntity.Name = request.Name;
                    currentEntity.Surname = request.Surname;
                    currentEntity.UserName = request.Username;
                    await db.SaveChangesAsync(cancellationToken);
                    return currentEntity;
                }
                return null;
            }
        }

    }
}
