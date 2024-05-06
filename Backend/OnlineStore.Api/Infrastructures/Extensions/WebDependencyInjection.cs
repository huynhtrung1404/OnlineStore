using OnlineStore.Api.Infrastructures.Services;
using OnlineStore.Application.Commons.Interfaces;

namespace OnlineStore.Api.Infrastructures.Extensions;
public static class WebDependencyInjection
{
    public static IServiceCollection AddWebApi(this IServiceCollection services)
    {
        services.AddScoped<IUserService, CurrentUserService>();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }
}