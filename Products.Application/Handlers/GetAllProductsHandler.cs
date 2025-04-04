using Products.Application.Mappers;
using Products.Application.Queries;
using Products.Application.Responses;
using Products.Core.Repositories;
using Products.Core.Specs;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Products.Application.Handlers;

public class GetAllProductsHandler: IRequestHandler<GetAllProductsQuery, Pagination<ProductResponse>>
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<GetAllProductsHandler> _logger;

    public GetAllProductsHandler(IProductRepository productRepository, ILogger<GetAllProductsHandler> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }
    public async Task<Pagination<ProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var productList = await _productRepository.GetProducts(request.CatalogSpecParams);
        var productResponseList = ProductMapper.Mapper.Map<Pagination<ProductResponse>>(productList);
        _logger.LogDebug("Received Product List.Total Count: {productList}", productResponseList.Count);
        return productResponseList;
    }
}