using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineStore.Application.Commons.Interfaces;
using OnlineStore.Domain.Commons.Interface;
using OnlineStore.Infrastructure.Databases.Contexts;
using OnlineStore.Infrastructure.Databases.Repositories;
using OnlineStore.Infrastructure.Services;
using OnlineStore.Shared.Common.Enums;

namespace OnlineStore.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<OnlineStoreContext>(option =>
            option.UseSqlServer(config.GetConnectionString(DefaultSchemas.OnlineStoreConnectionString),
            x =>
            {
                x.EnableRetryOnFailure((int)Times.Fifth);
                x.MigrationsAssembly("OnlineStore.Infrastructure");
            }));
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped(typeof(IOnlineStoreRepository<>), typeof(OnlineStoreRepository<>));
        services.AddTransient<IDateTimeService, DateTimeService>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<ITokenService, TokenService>();
        return services;
    }
}