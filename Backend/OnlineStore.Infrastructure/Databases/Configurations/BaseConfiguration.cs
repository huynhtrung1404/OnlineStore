using OnlineStore.Infrastructure.Databases.Converters;

namespace OnlineStore.Infrastructure.Databases.Configurations;
public class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity<Guid>
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.CreatedDate).HasConversion<ConvertDateOnly>().HasDefaultValue(DateOnly.FromDateTime(DateTime.UtcNow)).ValueGeneratedOnAdd();
        builder.Property(x => x.UpdatedDate).HasConversion<ConvertDateOnly>().HasDefaultValue(DateOnly.FromDateTime(DateTime.UtcNow)).ValueGeneratedOnUpdate();
        builder.Property(x => x.CreatedBy).HasMaxLength(255);
        builder.Property(x => x.UpdatedBy).HasMaxLength(255);
        builder.Property(x => x.Version).IsRowVersion();
        builder.Property(x => x.CreatedDateTime).HasDefaultValue(DateTime.UtcNow);
    }
}