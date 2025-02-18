namespace OnlineStore.Application.DTOs;
public class CategoryToProductDto
{
    public IEnumerable<Guid> CategoryIds { get; set; } = default!;
    public Guid ProductId { get; set; } = default!;
}