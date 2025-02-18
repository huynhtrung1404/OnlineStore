
namespace OnlineStore.Infrastructure.Databases.Configurations;
public class AccountConfiguration : BaseConfiguration<Account>
{
    public override void Configure(EntityTypeBuilder<Account> builder)
    {
        base.Configure(builder);
        builder.ToTable("Accounts");
        builder.Property(x => x.UserName).IsRequired();
        builder.HasIndex(x => x.UserName);
        builder.Property(x => x.Password).IsRequired();
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.Mobile).HasMaxLength(11);
    }
}