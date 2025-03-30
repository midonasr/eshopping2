using Products.Core.Entities; 

namespace Products.Application.Responses;

public class ProductResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public string ImageFile { get; set; }
    public decimal Price { get; set; }
    public Int64? BrandId { get; set; }
    public Int64? TypeId { get; set; }
}