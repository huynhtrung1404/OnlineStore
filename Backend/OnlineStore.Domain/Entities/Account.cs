using OnlineStore.Shared.Common.Enums;

namespace OnlineStore.Domain.Entities;
public class Account : BaseEntity<Guid>
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public string? Email { get; set; }
    public string? Mobile { get; set; }
    public Permission Permission { get; set; }
    /// <summary>
    /// Will be implement in the future
    /// </summary>
    public bool Enabled2FA { get; set; } = false;
    public virtual Customer Customer { get; set; } = default!;
    public Guid? CustomerId { get; set; }
}