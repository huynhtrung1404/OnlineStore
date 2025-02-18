using Microsoft.OpenApi.Models;
using OnlineStore.Api.Infrastructures.Services;
using OnlineStore.Api.Services;
using OnlineStore.Application.Commons.Interfaces;

namespace OnlineStore.Api.Infrastructures.Extensions;
public static class WebDependencyInjection
{
    public static IServiceCollection AddWebApi(this IServiceCollection services)
    {
        services.AddTransient<IUserService, CurrentUserService>();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(
            option =>
                {
                    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
                    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "Please enter a valid token",
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        BearerFormat = "JWT",
                        Scheme = "Bearer"
                    });
                    option.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type=ReferenceType.SecurityScheme,
                                    Id="Bearer"
                                }
                            },
                            new string[]{}
                        }
                    });
                });
        services.AddHttpContextAccessor();
        services.AddTransient<ICookieService, CookieService>();
        return services;
    }
}