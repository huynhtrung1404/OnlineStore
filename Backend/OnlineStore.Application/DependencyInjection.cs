using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using OnlineStore.Application.Services;

namespace OnlineStore.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IProductService, ProductService>();
        services.AddLogging(cfg =>
        {
            cfg.ClearProviders();
            cfg.AddConsole();
        });
        return services;
    }
}