
using Products.Core.Entities;

namespace Products.Core.Repositories
{
    public interface IBrandRepository : IAsyncRepository<Product>
    {
        Task<IEnumerable<ProductBrand>> GetAllBrands();
    }
}
