using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineStore.Domain.Commons.Interface;
using OnlineStore.Infrastructure.Databases.Contexts;
using OnlineStore.Infrastructure.Databases.Repositories;

namespace OnlineStore.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<OnlineStoreContext>(option => option.UseSqlServer(config.GetConnectionString("DefaultConnection")));
        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        return services;
    }
}