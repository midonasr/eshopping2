using Microsoft.EntityFrameworkCore;
using Products.Core.Entities;
using Products.Core.Repositories;
using Products.Core.Specs;
using Products.Infrastructure.Data;


namespace Products.Infrastructure.Repositories;

public class ProductRepository : RepositoryBase<Product>, IProductRepository, IBrandRepository, ITypesRepository
{
   
    public ProductRepository(CatalogContext dbContext) : base(dbContext)
    {
       
    }

    public async Task<Pagination<Product>> GetProducts(CatalogSpecParams catalogSpecParams)
    {
        IQueryable<Product> builder = _dbContext.Products;

        if (!string.IsNullOrEmpty(catalogSpecParams.Search))
        {
            builder = builder.Where(a => a.Name.ToLower().Contains(catalogSpecParams.Search.ToLower()));
        }
        if (catalogSpecParams.BrandId.HasValue)
        {
            builder = builder.Where(x => x.Brands.Id == catalogSpecParams.BrandId);
        }
        if (catalogSpecParams.TypeId.HasValue)
        {
            builder = builder.Where(x => x.Types.Id == catalogSpecParams.TypeId);

        }

        if (!string.IsNullOrEmpty(catalogSpecParams.Sort))
        {
            switch (catalogSpecParams.Sort)
            {
                case "priceAsc":
                    builder = builder.OrderBy(a => a.Price.ToString());
                    break;
                case "priceDesc":
                    builder = builder.OrderByDescending(a => a.Price.ToString());
                    break;
                default:
                    builder = builder.OrderByDescending(a => a.Id);
                    break;
            }
        }

        return new Pagination<Product>
        {
            PageSize = catalogSpecParams.PageSize,
            PageIndex = catalogSpecParams.PageIndex,
            Data = await builder
                .Skip(catalogSpecParams.PageSize * (catalogSpecParams.PageIndex - 1))
                .Take(catalogSpecParams.PageSize)
                .ToListAsync(),
            Count = await builder.CountAsync()
        };
    }



    public async Task<Product> GetProduct(int id)
    {
        return await _dbContext
            .Products
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Product>> GetProductByName(string name)
    {
        return await _dbContext
            .Products.Where(a => a.Name.ToLower().Contains(name.ToLower()))
            .ToListAsync();

    }

    public async Task<IEnumerable<Product>> GetProductByBrand(string name)
    {
        return await _dbContext.Brands.Where(a => a.Name.ToLower().Contains(name.ToLower()))
            .SelectMany(a => a.Products)
            .ToListAsync();
    }

    public async Task<Product> CreateProduct(Product product)
    {
        var updateResult = await _dbContext
            .Products.AddAsync(product);
        if (await _dbContext.SaveChangesAsync() > 0)
            return product;
        return null;
    }

    public async Task<bool> UpdateProduct(Product product)
    {
        if (product == null) return false;
       

        var updateResult = _dbContext
            .Products.Update(product);
        return await _dbContext.SaveChangesAsync() > 0;

    }

    public async Task<bool> DeleteProduct(int id)
    {
        var filter = await _dbContext.Products.SingleOrDefaultAsync(a => a.Id == id);
        if (filter != null)
        {
            _dbContext.Products.Remove(filter);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        return false;
   
    }

    public async Task<IEnumerable<ProductBrand>> GetAllBrands()
    {
        return await _dbContext
            .Brands
            .ToListAsync();
    }

    public async Task<IEnumerable<ProductType>> GetAllTypes()
    {
        return await _dbContext
            .Types
            .ToListAsync();
    }

}