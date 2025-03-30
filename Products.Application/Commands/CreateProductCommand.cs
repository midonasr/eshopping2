using Products.Application.Responses;
using Products.Core.Entities;
using MediatR;

namespace Products.Application.Commands;

public class CreateProductCommand: IRequest<ProductResponse>
{
    public string Name { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public string ImageFile { get; set; }
    public decimal Price { get; set; }
    public Int64? BrandId { get; set; }
    public Int64? TypeId { get; set; }
}