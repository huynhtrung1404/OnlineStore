using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using OnlineStore.Application.Commons.Interfaces;
using OnlineStore.Application.Services;

namespace OnlineStore.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddTransient<IProductService, ProductService>();
        return services;
    }
}