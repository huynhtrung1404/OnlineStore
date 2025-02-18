using AutoMapper;
using OnlineStore.Application.Specification;
using OnlineStore.Domain.Commons.Interface;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Services;
public class ProductService : IProductService
{
    private readonly IOnlineStoreRepository<Product> _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductService(IOnlineStoreRepository<Product> productRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) =>
            (_productRepository, _unitOfWork, _mapper) = (productRepository, unitOfWork, mapper);

    public async Task<bool> AddProductAsync(ProductDto product)
    {
        await _productRepository.InsertAsync(_mapper.Map<Product>(product));
        await _unitOfWork.CommitChangesAsync();
        return true;
    }

    public async Task DeleteAsync(Guid id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product is null)
            throw new NullReferenceException(ErrorMessage.NotFoundData);
        _productRepository.Remove(product);
        await _unitOfWork.CommitChangesAsync();
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductAsync()
    {
        var result = await _productRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductDto>>(result);
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductAsync(long pageSize, long pageNumber)
    {
        var result = await _productRepository.GetListAsync(new ProductSpecification(pageSize, pageNumber));
        return _mapper.Map<IEnumerable<ProductDto>>(result);
    }

    public async Task<ProductDto> GetProductByIdAsync(Guid id)
    {
        var result = await _productRepository.GetByIdAsync(id);
        return _mapper.Map<ProductDto>(result);
    }

    public async Task<bool> UpdateProductAsync(ProductDto product)
    {
        _productRepository.Update(_mapper.Map<Product>(product));
        await _unitOfWork.CommitChangesAsync();
        return true;
    }
}