using Products.Application.Responses;
using MediatR;

namespace Products.Application.Queries;

public class GetProductByIdQuery: IRequest<ProductResponse>
{
    public int Id { get; set; }

    public GetProductByIdQuery(int id)
    {
        Id = id;
    }
}