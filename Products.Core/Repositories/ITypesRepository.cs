using Products.Core.Entities;

namespace Products.Core.Repositories;

public interface ITypesRepository : IAsyncRepository<Product>
{
    Task<IEnumerable<ProductType>> GetAllTypes();
}