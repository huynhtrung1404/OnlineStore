using OnlineStore.Shared.Common.Enums;

namespace OnlineStore.Domain.Entities;
public class Customer : BaseEntity<Guid>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public bool IsActive { get; set; }
    public DateTime DOB { get; set; }
    public Gender Gender { get; set; }
    public required string Address { get; set; }
    public string? Address2 { get; set; }
    public required string City { get; set; }
    public required string Province { get; set; }
}