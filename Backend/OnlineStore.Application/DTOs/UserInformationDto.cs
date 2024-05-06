using Newtonsoft.Json;

namespace OnlineStore.Application.DTOs;
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class UserInfoDto
{
    public string? UserName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Token { get; set; }
    public string? RefreshToken { get; set; }
}