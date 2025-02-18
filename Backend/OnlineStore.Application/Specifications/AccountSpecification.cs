using OnlineStore.Application.Commons.Specifications;

namespace OnlineStore.Application.Specifications;
public class AccountSpecification : BaseSpecification<Account>
{
    public AccountSpecification(string userName, string password)
        : base(x => x.UserName.Equals(userName) && x.Password.Equals(password))
    {
        AddInclude(x => x.Customer);
    }
    public AccountSpecification(string userName)
        : base(x => x.UserName.Equals(userName))
    {
        AddInclude(x => x.Customer);
    }
}