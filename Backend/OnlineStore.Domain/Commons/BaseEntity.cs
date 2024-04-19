using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Domain.Commons;
public class BaseEntity<T>
{
    public required T Id { get; set; }
    public DateOnly? CreatedDate { get; set; }
    public string? CreatedBy { get; set; }
    public DateOnly? UpdatedDate { get; set; }
    public string? UpdatedBy { get; set; }
    [Timestamp]
    public byte[]? Version { get; set; }
    public DateTime CreatedDateTime { get; set; }
}