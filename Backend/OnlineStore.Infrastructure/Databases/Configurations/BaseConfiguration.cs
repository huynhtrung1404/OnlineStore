namespace OnlineStore.Infrastructure.Databases.Configurations;
public class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity<Guid>
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.CreatedDate).ValueGeneratedOnAdd();
        builder.Property(x => x.UpdatedDate).ValueGeneratedOnUpdate();
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
    }
}