using Products.Application.Responses;
using Products.Core.Specs;
using MediatR;

namespace Products.Application.Queries;

public class GetAllProductsQuery : IRequest<Pagination<ProductResponse>>
{
    public CatalogSpecParams CatalogSpecParams { get; set; }

    public GetAllProductsQuery(CatalogSpecParams catalogSpecParams)
    {
        CatalogSpecParams = catalogSpecParams;
    }
}