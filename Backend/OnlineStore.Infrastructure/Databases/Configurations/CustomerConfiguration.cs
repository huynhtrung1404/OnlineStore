
namespace OnlineStore.Infrastructure.Databases.Configurations;
public class CustomerConfiguration : BaseConfiguration<Customer>
{
    public override void Configure(EntityTypeBuilder<Customer> builder)
    {
        base.Configure(builder);
        builder.ToTable("Customers");
        builder.Property(x => x.Address).IsRequired();
        builder.Property(x => x.City).IsRequired();
        builder.Property(x => x.FirstName).IsRequired();
        builder.HasIndex(x => x.FirstName);
        builder.HasIndex(x => x.LastName);
    }
}