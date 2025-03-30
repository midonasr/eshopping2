using Products.Core.Entities;
using Products.Core.Specs;

namespace Products.Core.Repositories;

public interface IProductRepository : IAsyncRepository<Product>
{
    Task<Pagination<Product>> GetProducts(CatalogSpecParams catalogSpecParams);
    Task<Product> GetProduct(int id);
    Task<IEnumerable<Product>> GetProductByName(string name);
    Task<IEnumerable<Product>> GetProductByBrand(string name);
    Task<Product> CreateProduct(Product product);
    Task<bool> UpdateProduct(Product product);
    Task<bool> DeleteProduct(int id);
}