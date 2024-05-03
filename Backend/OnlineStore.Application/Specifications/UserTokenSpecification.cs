using OnlineStore.Application.Commons.Specifications;
using OnlineStore.Domain.Entity;

namespace OnlineStore.Application.Specifications;
public class UserTokenSpecification : BaseSpecification<UserToken>
{
    public UserTokenSpecification(Guid accountId) : base(x => x.AccountId.Equals(accountId))
    {
    }
}