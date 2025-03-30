using Products.Application.Commands;
using Products.Application.Mappers;
using Products.Application.Responses;
using Products.Core.Entities;
using Products.Core.Repositories;
using MediatR;

namespace Products.Application.Handlers;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductResponse>
{
    private readonly IProductRepository _productRepository;

    public CreateProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var productEntity = ProductMapper.Mapper.Map<Product>(request);
        if (productEntity is null)
        {
            throw new ApplicationException("There is an issue with mapping while creating new product");
        }

        var newProduct = await _productRepository.CreateProduct(productEntity);
        var productResponse = ProductMapper.Mapper.Map<ProductResponse>(newProduct);
        return productResponse;
    }
}