using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineStore.Domain.Commons.Interface;
using OnlineStore.Infrastructure.Databases.Contexts;
using OnlineStore.Infrastructure.Databases.Repositories;
using OnlineStore.Shared.Common.Enums;

namespace OnlineStore.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<OnlineStoreContext>(option =>
            option.UseSqlServer(config.GetConnectionString(DefaultSchemas.OnlineStoreConnectionString),
            x => x.EnableRetryOnFailure((int)Times.Fifth)));
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped(typeof(IOnlineStoreRepository<>), typeof(OnlineStoreRepository<>));
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        return services;
    }
}