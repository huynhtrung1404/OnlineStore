using System.Security.Claims;
using OnlineStore.Application.Commons.Interfaces;

namespace OnlineStore.Api.Infrastructures.Services;
public class CurrentUserService : IUserService
{
    private readonly IHttpContextAccessor _context;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _context = httpContextAccessor;
    }

    public string FirstName => throw new NotImplementedException();

    public string LastName => throw new NotImplementedException();

    public string Role => throw new NotImplementedException();

    public string UserName
    {
        get
        {
            var data = _context.HttpContext?.User.Identity as ClaimsIdentity;
            if (data is not null)
            {
                var result = data.FindFirst("UserName")?.Value ?? string.Empty;
                return result;
            }
            return string.Empty;
        }
    }

    public Guid SessionId
    {
        get
        {
            var data = _context.HttpContext?.User.Identity as ClaimsIdentity;
            if (data is not null)
            {
                var result = data.FindFirst("SessionId")?.Value ?? string.Empty;
                return Guid.Parse(result);
            }
            return Guid.Empty;
        }
    }
    public bool IsAuthenticated => _context.HttpContext?.User?.Identity?.IsAuthenticated
                                    ?? throw new ArgumentNullException("Cannot check context");
}