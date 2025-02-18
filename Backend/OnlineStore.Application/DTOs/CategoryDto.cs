namespace OnlineStore.Application.DTOs;
public class CategoryDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? TagName { get; set; }
    public DateOnly? CreatedDate { get; set; }
    public DateOnly? UpdatedDate { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public bool IsEnabled { get; set; }
}