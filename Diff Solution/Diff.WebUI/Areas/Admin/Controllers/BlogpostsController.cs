using Diff.WebUI.AppCode.Infrastructure;
using Diff.WebUI.AppCode.Modules.BlogpostModule;
using Diff.WebUI.Models.DataContexts;
using Diff.WebUI.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Diff.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogpostsController : Controller
    {
        private readonly DiffDbContext db;
        private readonly IWebHostEnvironment env;
        private readonly IMediator mediator;

        public BlogpostsController(DiffDbContext db, IWebHostEnvironment env, IMediator mediator)
        {
            this.db = db;
            this.env = env;
            this.mediator = mediator;
        }

        // GET: Admin/Blogposts
        public async Task<IActionResult> Index( int pageIndex=1, int pageSize=20)
        {

            var query = db.Blogposts
                .Include(b => b.Category)
                .Where(b => b.DeletedById == null);

            var pagedModel = new PagedViewModel<Blogpost>(query, pageIndex,pageSize);

         
            return View(pagedModel); 
        }

        // GET: Admin/Blogposts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogpost = await db.Blogposts
                .Include(b => b.Category)
                .FirstOrDefaultAsync(m => m.Id == id && m.DeletedById == null);
            if (blogpost == null)
            {
                return NotFound();
            }

            return View(blogpost);
        }

        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Name");
            ViewData["TagId"] = new SelectList(db.PostTags, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogpostCreateCommand command)
        {

            var response = await mediator.Send(command);
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }


            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Name", command.CategoryId); 
            ViewData["TagId"] = new SelectList(db.PostTags, "Id", "Name");
            return View(command);
        }

        // GET: Admin/Blogposts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogpost = await db.Blogposts
                .Include(bp=>bp.TagCloud)
                .FirstOrDefaultAsync(bp => bp.Id == id && bp.DeletedById == null);
            if (blogpost == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Name", blogpost.CategoryId);
            ViewData["TagId"] = new SelectList(db.PostTags, "Id", "Name");
            return View(blogpost);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id, Blogpost blogpost, IFormFile file, int[] tagIds)
        {
            if (id != blogpost.Id)
            {
                return NotFound();
            }

            if (file == null && string.IsNullOrWhiteSpace(blogpost.ImagePath))
            {
                ModelState.AddModelError("ImagePath", "Fayl seçilməyib");
            }


            if (ModelState.IsValid)
            {
                try
                {
                    var currentEntity = db.Blogposts
                        .FirstOrDefault(bp => bp.Id == id);
                    if (currentEntity == null)
                    {
                        return NotFound();
                    }
                    string oldFileName = currentEntity.ImagePath;

                    if (file != null)
                    {
                        string fileExtension = Path.GetExtension(file.FileName);

                        string name = $"blog-image-{Guid.NewGuid()}{fileExtension}";

                        string phsicalPath = Path.Combine(env.ContentRootPath, "wwwroot", "uploads", "images", "blogs", name);


                        using (var fs = new FileStream(phsicalPath, FileMode.Create, FileAccess.Write))
                        {
                            await file.CopyToAsync(fs);
                        }
                        currentEntity.ImagePath = name;

                        string physicalPathOld = Path.Combine(env.ContentRootPath, "wwwroot", "uploads", "images", "blogs", oldFileName);
                        if (System.IO.File.Exists(physicalPathOld))
                        {
                            System.IO.File.Delete(physicalPathOld);
                        }

                    }
                    currentEntity.CategoryId = blogpost.Id;
                    currentEntity.Title = blogpost.Title;
                    currentEntity.Body = blogpost.Body;
                    if (tagIds != null && tagIds.Length > 0)
                    {
                        foreach (var item in tagIds)
                        {
                            if (db.BlogPostTagClouds.Any(bptc => bptc.PostTagId == item && bptc.BlogPostId == blogpost.Id))
                            {
                                continue;
                            }
                            await db.BlogPostTagClouds.AddAsync(new BlogPostTag
                            {
                                BlogPostId = blogpost.Id,
                                PostTagId = item
                            });
                        }
                    }
                    await db.SaveChangesAsync();



                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogpostExists(blogpost.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Name", blogpost.CategoryId);
            ViewData["TagId"] = new SelectList(db.PostTags, "Id", "Name");
            return View(blogpost);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var blogpost = await db.Blogposts
                .FirstOrDefaultAsync(bp => bp.Id == id && bp.DeletedById == null);
            if (blogpost == null)
            {
                return Json(new
                {
                    error = true,
                    message = "Mövcud deyil"
                });
            }

            blogpost.DeletedById = 1;
            blogpost.DeletedDate = DateTime.UtcNow.AddHours(4);

            await db.SaveChangesAsync();

            return Json(new
            {
                error = false,
                message = "Silindi"
            });
        }

        private bool BlogpostExists(int id)
        {
            return db.Blogposts.Any(e => e.Id == id);
        }
    }
}
