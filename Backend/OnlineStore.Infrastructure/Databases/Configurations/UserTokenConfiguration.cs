using OnlineStore.Domain.Entity;

namespace OnlineStore.Infrastructure.Databases.Configurations;
public class UserTokenConfiguration : BaseConfiguration<UserToken>
{
    public override void Configure(EntityTypeBuilder<UserToken> builder)
    {
        base.Configure(builder);
        builder.ToTable("UserTokens");
        builder.Property(x => x.CreatedBy).HasDefaultValue("Current System");
        builder.Property(x => x.RefreshToken).IsRequired();
        builder.HasIndex(x => x.RefreshToken);
    }
}