using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Products.Core.Repositories;
using Products.Infrastructure.Data;
using Products.Infrastructure.Repositories;

namespace Products.Infrastructure.Extensions;

public static class InfraServices
{
    public static IServiceCollection AddInfraServices(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddDbContext<CatalogContext>(options => options.UseSqlite(
            configuration.GetConnectionString("default")));
        serviceCollection.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
        serviceCollection.AddScoped<IProductRepository, ProductRepository>();
        serviceCollection.AddScoped<IAuthRepository, AuthRepository>();
        serviceCollection.AddScoped<IBrandRepository, ProductRepository>();
        serviceCollection.AddScoped<ITypesRepository, ProductRepository>();
        return serviceCollection;
    }
}