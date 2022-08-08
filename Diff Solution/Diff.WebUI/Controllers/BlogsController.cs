using Diff.WebUI.Models.DataContexts;
using Diff.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Diff.WebUI.Controllers
{
    [AllowAnonymous]
    public class BlogsController : Controller
    {
        readonly DiffDbContext db;
        public BlogsController(DiffDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var data = db.Blogposts
                .Where(bp => bp.DeletedById == null)
                .ToList();
            return View(data);
        }

        public IActionResult Details(int id)
        {

            var entity = db.Blogposts
                .Include(bp => bp.TagCloud)
                .ThenInclude(tc => tc.PostTag)
                .FirstOrDefault(item => item.Id == id && item.DeletedById == null);

            if (entity == null)
            {
                return NotFound();
            }

            var vm = new SinglePostViewModel();

            vm.Post = entity;

            var relatedTagIdsQuery = entity.TagCloud.Select(bp => bp.PostTagId);
            //method
            vm.RelatedPosts = db.Blogposts
                .Include(bp => bp.TagCloud)
                .ThenInclude(tc => tc.PostTag)
                .Where(bp => bp.Id != id && bp.DeletedById == null
                && bp.TagCloud.Any(tc => relatedTagIdsQuery.Any(q => q == tc.PostTagId)))
                .OrderByDescending(bp => bp.Id)
                .Take(15)
                .ToList();


            //query
            //vm.RelatedPosts = (from bp in db.BlogPosts
            //                   join tc in db.BlogPostTagCloud on bp.Id equals tc.BlogPostId
            //                   where bp.Id != id && bp.DeletedDateTime == null 
            //                   && relatedTagIdsQuery.Any(q=>q == tc.PostTagId)
            //                   select bp)
            //                   .Distinct()
            //                   .ToList();



            return View(vm);
        }
    }
}

