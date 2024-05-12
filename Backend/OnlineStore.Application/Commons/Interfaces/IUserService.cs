namespace OnlineStore.Application.Commons.Interfaces;
public interface IUserService
{
    string FirstName { get; }
    string LastName { get; }
    string Role { get; }
    string UserName { get; }
    Guid SessionId { get; }
    bool IsAuthenticated { get; }
}