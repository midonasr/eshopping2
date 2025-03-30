using Products.Application.Responses;
using MediatR;

namespace Products.Application.Queries;

public class GetAllBrandsQuery : IRequest<IList<BrandResponse>>
{
    
}