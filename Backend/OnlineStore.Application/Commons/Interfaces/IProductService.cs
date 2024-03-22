namespace OnlineStore.Application.Commons.Interfaces;
public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllProductAsync();
    Task<ProductDto> GetProductByIdAsync(Guid id);
    Task<bool> AddProductAsync(ProductDto product);
    Task<bool> UpdateProductAsync(ProductDto product);
    Task DeleteAsync(Guid id);
}