using Diff.WebUI.Models.Entities;
using System.Collections.Generic;

namespace Diff.WebUI.Models.ViewModels
{
    public class ShopIndexViewModel
    {
        public List<Category> Categories{ get; set; }
        public List<Brand> Brands{ get; set; }  
        public List<ProductSize> ProductSizes { get; set; }
        public List<ProductColor> ProductColors { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<Faq> Faqs { get; set; }


    }
}
