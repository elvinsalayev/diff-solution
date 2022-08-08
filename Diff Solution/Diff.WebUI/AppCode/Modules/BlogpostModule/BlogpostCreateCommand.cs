using Diff.WebUI.AppCode.Extensions;
using Diff.WebUI.Models.DataContexts;
using Diff.WebUI.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Diff.WebUI.AppCode.Modules.BlogpostModule
{
    public class BlogpostCreateCommand : IRequest<Blogpost>
    {

        public string Title { get; set; }
        public string Body { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public IFormFile File{ get; set; }
        public int[] TagIds { get; set; }
        public class BlogpostCreateCommandHandler : IRequestHandler<BlogpostCreateCommand, Blogpost>
        {
            readonly DiffDbContext db;
            readonly IWebHostEnvironment env;
            readonly IActionContextAccessor ctx;
            public BlogpostCreateCommandHandler(DiffDbContext db,
                IWebHostEnvironment env,
                IActionContextAccessor ctx)
            {
                this.db = db;
                this.env = env;
                this.ctx = ctx;
            }
            public async Task<Blogpost> Handle(BlogpostCreateCommand request, CancellationToken cancellationToken)
            {
                if (request?.File == null)
                {
                    ctx.AddModelError("ImagePath", "Fayl seçilməyib.");
                }


                if (ctx.ModelIsValid())
                {
                    string fileExtension = Path.GetExtension(request.File.FileName);

                    string name = $"blog-image-{Guid.NewGuid()}{fileExtension}";
                    
                    string phsicalPath = Path.Combine(env.ContentRootPath, "wwwroot", "uploads", "images", "blogs", name);

                    using (var fs = new FileStream(phsicalPath, FileMode.Create, FileAccess.Write))
                    {
                       await request.File.CopyToAsync(fs, cancellationToken);
                    }

                    var blog = new Blogpost
                    {
                        Title = request.Title,
                        Body = request.Body,
                        CategoryId = request.CategoryId,
                        ImagePath = name
                    };

                    await db.AddAsync(blog, cancellationToken);
                    int affected = await db.SaveChangesAsync(cancellationToken);

                    if (affected > 0 && request.TagIds != null && request.TagIds.Length > 0)
                    {
                        foreach (var item in request.TagIds)
                        {
                            await db.BlogPostTagClouds.AddAsync(new BlogPostTag
                            {
                                BlogPostId = blog.Id,
                                PostTagId = item
                            }, cancellationToken);
                        }
                        await db.SaveChangesAsync(cancellationToken);
                    }

                    return blog;
                }


                return null;
  
            }
        }
    }
}
