namespace OnlineStore.Domain.Entities;
public class Category : BaseEntity<Guid>
{
    public string? Description { get; set; }
    public string? TagName { get; set; }
    public bool IsEnabled { get; set; }
    public IList<Product> Products { get; } = new List<Product>();
    public required string Name { get; set; }
}