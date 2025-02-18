using Microsoft.EntityFrameworkCore;
using OnlineStore.Infrastructure.Databases.Contexts;

namespace OnlineStore.Api.Infrastructures.Extensions;
public static class MigrationExtension
{
    public static WebApplication UseApplyMigration(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<OnlineStoreContext>();
        dbContext.Database.Migrate();
        return app;
    }
}