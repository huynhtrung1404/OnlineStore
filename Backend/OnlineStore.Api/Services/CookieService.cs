using OnlineStore.Application.Commons.Interfaces;

namespace OnlineStore.Api.Services;
public class CookieService : ICookieService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private CookieOptions _cookieOptions;
    private readonly IDateTimeService _dateTimeService;

    public CookieService(IHttpContextAccessor httpContextAccessor, IDateTimeService dateTimeService)
    {
        _httpContextAccessor = httpContextAccessor;
        _cookieOptions = new();
        _dateTimeService = dateTimeService;
    }

    public string? Get(string name)
    {
        return _httpContextAccessor.HttpContext?.Request?.Cookies?.SingleOrDefault(x => x.Key == name).Value?.ToString();
    }

    public void Remove(string name)
    {
        _httpContextAccessor.HttpContext?.Response.Cookies.Delete(name);
    }

    public void Save(string name, string value)
    {
        _cookieOptions.HttpOnly = true;
        _cookieOptions.Expires = _dateTimeService.Now.AddDays(1);
        _cookieOptions.SameSite = SameSiteMode.None;
        _httpContextAccessor.HttpContext?.Response.Cookies.Append(name, value, _cookieOptions);
    }

    public void RemoveAll()
    {
        foreach (var cookie in _httpContextAccessor.HttpContext?.Request.Cookies!)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(cookie.Key);
        }
    }
}