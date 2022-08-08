using Diff.WebUI.AppCode.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diff.WebUI.Models.Entities
{
    public class ProductPricing : HistoryEntity
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int ProductColorId { get; set; }
        public virtual ProductColor ProductColor { get; set; }
        public int ProductSizeId { get; set; }

        [ForeignKey("ProductSizeId")]
        public virtual ProductSize ProductSize { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public double Price { get; set; }
    }
}
