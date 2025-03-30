using MediatR;

namespace Products.Application.Queries;

public class DeleteProductByIdQuery : IRequest<bool>
{
    public int Id { get; set; }

    public DeleteProductByIdQuery(int id)
    {
        Id = id;
    }
}