using OnlineStore.Shared.Common.Enums;

namespace OnlineStore.Application.DTOs;
public class AccountDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
    public DateTime DOB { get; set; }
    public required string Address { get; set; }
    public string? Address2 { get; set; }
    public required string City { get; set; }
    public required string Province { get; set; }
    public Gender Gender { get; set; }
}