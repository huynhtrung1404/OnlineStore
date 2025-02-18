namespace OnlineStore.Domain.Entities;
public class Product : BaseEntity<Guid>
{
    public string? Category { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public long StockUnit { get; set; }
    public bool IsSales { get; set; }
    public long QuantitySold { get; set; }
    public IList<Category> Categories { get; } = new List<Category>();
    public required string Name { get; set; }
}