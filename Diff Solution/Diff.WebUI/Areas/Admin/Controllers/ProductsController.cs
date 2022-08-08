using Diff.WebUI.AppCode.Extensions;
using Diff.WebUI.AppCode.Infrastructure;
using Diff.WebUI.AppCode.Modules.ProductModule;
using Diff.WebUI.Models.DataContexts;
using Diff.WebUI.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Diff.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        readonly DiffDbContext db;
        readonly IMediator mediator;

        public ProductsController(DiffDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }




        public async Task<IActionResult> Index()
        {
            var diffDbContext = db.Products
               .Include(p => p.Brand)
               .Include(p => p.Category)
               .Include(p => p.Images.Where(i => i.IsMain == true));
            return View(await diffDbContext.ToListAsync());

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await db.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(db.Brands.Where(s => s.DeletedById == null), "Id", "Name");
            ViewData["CategoryId"] = new SelectList(db.Categories.Where(s => s.DeletedById == null), "Id", "Name");
            ViewBag.ProductColors = new SelectList(db.ProductColors.Where(s => s.DeletedById == null), "Id", "Name");
            ViewBag.ProductSizes = new SelectList(db.ProductSizes.Where(s => s.DeletedById == null), "Id", "Name");


            ViewBag.Specifications = db.Specifications.Where(s => s.DeletedById == null).ToList();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateCommand command)
        {
            var response = await mediator.Send(command);

            if (response?.ValidationResult != null && !response.ValidationResult.IsValid)
            {
                return Json(response.ValidationResult);
            }

            return Json(new CommandJsonResponse(false, $"Ugurlu emeliyyat, yeni mehsul: ")); //sehvlik var
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await db.Products
                .Include(p => p.Images)
                .Include(p => p.Specifications)

                .Include(p => p.Pricing)
                .ThenInclude(p => p.ProductColor)

                .Include(p => p.Pricing)
                .ThenInclude(p => p.ProductSize)

                .FirstOrDefaultAsync(p => p.Id == id);

             
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.ProductColors = new SelectList(db.ProductColors.Where(s => s.DeletedById == null), "Id", "Name");
            ViewBag.ProductSizes = new SelectList(db.ProductSizes.Where(s => s.DeletedById == null), "Id", "Name");


            ViewBag.Specifications = db.Specifications.Where(s => s.DeletedById == null).ToList();

            ViewData["BrandId"] = new SelectList(db.Brands, "Id", "Name", product.BrandId);
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Name", product.CategoryId);

            return View(product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductEditCommand command)
        {

            
                var response = await mediator.Send(command);

                if (response?.ValidationResult != null && !response.ValidationResult.IsValid)
                {
                    return Json(response.ValidationResult);
                }

                return Json(new CommandJsonResponse(false, $"Ugurlu emeliyyat, yeni mehsul: ")); //sehvlik var
            

           
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await db.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await db.Products.FindAsync(id);
            db.Products.Remove(product);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return db.Products.Any(e => e.Id == id);
        }
    }
}
