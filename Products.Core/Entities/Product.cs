using System.ComponentModel.DataAnnotations.Schema;

namespace Products.Core.Entities
{
    public class Product : BaseEntity
    { 
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        [ForeignKey("BrandId")]
        public virtual ProductBrand Brands { get; set; }
        [ForeignKey("TypeId")]
        public virtual ProductType Types { get; set; } 
        public decimal Price { get; set; }
        public Int64? BrandId { get; set; }
        public Int64? TypeId { get; set; }
    }
}