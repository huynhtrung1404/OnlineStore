namespace OnlineStore.Application.DTOs;
public class LoginDto
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public bool IsKeptLogin { get; set; }
}