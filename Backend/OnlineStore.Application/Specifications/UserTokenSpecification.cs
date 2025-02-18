using OnlineStore.Application.Commons.Specifications;
using OnlineStore.Domain.Entity;

namespace OnlineStore.Application.Specifications;
public class UserTokenSpecification : BaseSpecification<UserToken>
{
    public UserTokenSpecification(Guid accountId) : base(x => x.AccountId.Equals(accountId))
    { }

    public UserTokenSpecification(Guid accountId, Guid sessionId) : base(x => x.AccountId.Equals(accountId) && x.SessionId.Equals(sessionId))
    { }
    public UserTokenSpecification(string refreshToken, DateTime dateTime) : base(x => x.RefreshToken == refreshToken && x.EndDate >= dateTime)
    { }
}