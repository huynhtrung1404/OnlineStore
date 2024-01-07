using OnlineStore.Infrastructure.Databases.Configurations;
using OnlineStore.Infrastructure.Databases.Converters;

namespace OnlineStore.Infrastructure.Databases.Contexts;
public class OnlineStoreContext : DbContext
{
    public OnlineStoreContext(DbContextOptions<OnlineStoreContext> options) : base(options)
    {

    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
        configurationBuilder.Properties<DateOnly>()
            .HaveConversion<ConvertDateOnly>();
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema(DefaultSchemas.OnlineStore);
        builder.ApplyConfigurationsFromAssembly(typeof(BaseConfiguration<>).Assembly);
    }
}