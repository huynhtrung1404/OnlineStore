using OnlineStore.Application.Specification;

namespace OnlineStore.Application.Features.Products.Commands;
public record AddCategoryToProductRequest(CategoryToProductDto Detail) : IRequest;
public sealed class AddCategoryToProductRequestHandler : IRequestHandler<AddCategoryToProductRequest>
{
    private readonly IOnlineStoreRepository<Product> _productRepository;
    private readonly IOnlineStoreRepository<Category> _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddCategoryToProductRequestHandler(IOnlineStoreRepository<Product> productRepository, IOnlineStoreRepository<Category> categoryRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(AddCategoryToProductRequest request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetItemAsync(new ProductSpecification(request.Detail.ProductId));
        if (product is null)
            throw new ArgumentNullException("Value is null");
        var categoryList = await _categoryRepository.GetListAsync(new CategorySpecification(request.Detail.CategoryIds));
        foreach (var item in categoryList)
        {
            product.Categories.Add(item);
        }
        _productRepository.Update(product);
        await _unitOfWork.CommitChangesAsync();
    }
}