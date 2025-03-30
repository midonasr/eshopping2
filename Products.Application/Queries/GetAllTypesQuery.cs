using Products.Application.Responses;
using MediatR;

namespace Products.Application.Queries;

public class GetAllTypesQuery : IRequest<IList<TypesResponse>>
{
    
}