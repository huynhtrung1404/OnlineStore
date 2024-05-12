using OnlineStore.Domain.Entities;

namespace OnlineStore.Domain.Entity;
public class UserToken : BaseEntity<Guid>
{
    public string? Token { get; set; }
    public DateTime EndDate { get; set; }
    public Guid? AccountId { get; set; }
    public Account? Account { get; set; }
    public Guid SessionId { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpire { get; set; }
}