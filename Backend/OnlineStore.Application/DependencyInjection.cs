using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OnlineStore.Application.Features.Tests.Behaviors;

namespace OnlineStore.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            config.AddOpenBehavior(typeof(LoggingBehaviors<,>));
        });
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddLogging(cfg =>
        {
            cfg.ClearProviders();
            cfg.AddConsole();
        });
        return services;
    }
}