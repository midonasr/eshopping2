using Products.Core.Entities;
using MediatR;


namespace Products.Application.Commands;

public class UpdateProductCommand : IRequest<bool>
{
    public int Id { get; set; } 
    public string Name { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public string ImageFile { get; set; }
    public decimal Price { get; set; }
    public int? BrandId { get; set; }
    public int? TypeId { get; set; }
}