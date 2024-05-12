namespace OnlineStore.Application.DTOs;
public class UserInfoDto
{
    public string? UserName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Token { get; set; }
    public string? RefreshToken { get; set; }
}