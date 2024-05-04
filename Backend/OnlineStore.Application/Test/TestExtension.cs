using Microsoft.Extensions.DependencyInjection;
using OnlineStore.Application.Features.Tests.Behaviors;

namespace OnlineStore.Application.Test;
public static class TestExtension
{
    public static IServiceCollection AddTestService(this IServiceCollection services)
    {
        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviors<,>));
        return services;
    }
}