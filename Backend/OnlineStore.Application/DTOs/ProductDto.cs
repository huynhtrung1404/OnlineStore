namespace OnlineStore.Application.DTOs;
public class ProductDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public long? StockUnit { get; set; }
    public DateOnly? CreatedDate { get; set; }
    public DateOnly? UpdatedDate { get; set; }
}