using Diff.WebUI.Models.DataContexts;
using Diff.WebUI.Models.Entities;
using Diff.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diff.WebUI.Controllers
{
    public class ShopController : Controller
    {
        readonly DiffDbContext db;
        public ShopController(DiffDbContext db)
        {
            this.db = db;
        }


        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = new ShopIndexViewModel();
            model.Brands = db.Brands.ToList();
            model.ProductSizes = db.ProductSizes.ToList();
            model.ProductColors = db.ProductColors.ToList();
            model.Categories = db.Categories
                .Include(c => c.Children)
                .ToList();

            model.Products = db.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.Images.Where(i => i.IsMain == true))
               .ToList();

            return View(model);
        }


        public IActionResult Cart()
        {
            if (Request.Cookies.TryGetValue("cards", out string cards))
            {
                int[] idsFromCookie = cards.Split(",").Where(CheckIsNumber)
                    .Select(item => int.Parse(item))
                    .ToArray();

                var products = from p in db.Products.Include(p => p.Images.Where(p => p.IsMain && p.DeletedById == null))
                               where idsFromCookie.Contains(p.Id) && p.DeletedById == null
                               select p;
                return View(products.ToList());
            }

            return View(new List<Product>());

        }

        public async Task<IActionResult> SearchInput(string key)
        {
            List<Product> products = new List<Product>();
            if (key != null)
            {
                products = await db.Products
                .Where(p => p.Name.Contains(key)
                || p.ShortDescription.Contains(key)
                || p.Category.Name.Contains(key)
                || p.Brand.Name.Contains(key))
                .Include(p => p.Images)
                .Include(p => p.Category)
                .ToListAsync();
            }
            return PartialView("_ProductListPartial", products);
        }

        private bool CheckIsNumber(string value)
        {
            return int.TryParse(value, out int v);
        }
    }
}