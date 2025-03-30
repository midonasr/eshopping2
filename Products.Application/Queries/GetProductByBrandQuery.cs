using Products.Application.Responses;
using MediatR;

namespace Products.Application.Queries;

public class GetProductByBrandQuery :  IRequest<IList<ProductResponse>>
{
    public string Brandname { get; set; }

    public GetProductByBrandQuery(string brandname)
    {
        Brandname = brandname;
    }
}