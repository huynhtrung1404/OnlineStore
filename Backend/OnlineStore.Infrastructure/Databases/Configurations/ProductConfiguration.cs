namespace OnlineStore.Infrastructure.Databases.Configurations;
public class ProductConfiguration : BaseConfiguration<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        base.Configure(builder);
        builder.ToTable("Products");
        builder.Property(x => x.Price).IsRequired().HasPrecision(18, 6);
        builder.Property(x => x.Description).HasMaxLength(500);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.HasIndex(x => x.Name);
    }
}