using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Diff.WebUI.Models.DataContexts;
using Diff.WebUI.Models.Entities;

namespace Diff.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly DiffDbContext db;

        public CategoriesController(DiffDbContext db)
        {
            this.db = db;
        }

        // GET: Admin/Categories
        public IActionResult Index()
        {
            var data = db.Categories
                .Include(c => c.Parent)
                .Include(c=>c.Children)
                .ToList();

            return View(data);
        }

        public IActionResult Create()
        {
            var categories = db.Categories.Include(c => c.Parent)
                .Select(BindParentName)
                .ToList();
            ViewBag.Categories = new SelectList(categories, "Id", "Name", null, "ParentName");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                var categories = db.Categories.Include(c => c.Parent)
                    .Select(BindParentName)
                    .ToList();

                ViewBag.Categories = new SelectList(categories, "Id", "Name", category.ParentId, "ParentName");
                return View(category);
            }

            db.Categories.Add(category);
            db.SaveChanges();

            return RedirectToAction(nameof(Index));

        }
        [NonAction]
        public Category BindParentName(Category c)
        {
            if (c.Parent == null)
            {
                c.ParentName = "---";
            }
            else
            {
                c.ParentName = c.Parent.Name;
            }
            return c;
        }


        public IActionResult Edit(int id)
        {
            var entity = db.Categories.FirstOrDefault(c => c.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            var categories = db.Categories.Include(c => c.Parent)
                   .Select(BindParentName)
                   .ToList();

            ViewBag.Categories = new SelectList(categories, "Id", "Name", entity.ParentId, "ParentName");

            return View(entity);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Category category)
        {
            if (!ModelState.IsValid)
            {
                goto end;
            }
            var entity = db.Categories.FirstOrDefault(c => c.Id == id);

            if (entity == null)
            {
                return NotFound();
            }
            if (category.ParentId == category.Id)
            {
                ModelState.AddModelError("ParentId", "Özü özünün valideyni ola bilməz.");
                goto end;
            }

            entity.Name = category.Name;
            entity.ParentId = category.ParentId;
            db.SaveChanges();

            return RedirectToAction(nameof(Index));

            end:
            var categories = db.Categories.Include(c => c.Parent)
                    .Select(BindParentName)
                    .ToList();

            ViewBag.Categories = new SelectList(categories, "Id", "Name", category.ParentId, "ParentName");

            return View(category);
        }



        public IActionResult Details(int id)
        {
            var entity = db.Categories.FirstOrDefault(c => c.Id == id);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int id)
        {
            var entity = db.Categories.FirstOrDefault(b => b.Id == id);
            if (entity == null)
            {
                return Json(new
                {
                    error = true,
                    message = "Mövcud deyil."
                });
            }

            db.Categories.Remove(entity);
            db.SaveChanges();

            return Json(new
            {
                error = false,
                message = "Silindi."
            });
        }


    }
}