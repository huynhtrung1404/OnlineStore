using AutoMapper;
using OnlineStore.Application.Commons.Interfaces;
using OnlineStore.Application.DTOs;
using OnlineStore.Domain.Commons.Interface;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Services;
public class ProductService : IProductService
{
    private readonly IGenericRepository<Product> _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductService(IGenericRepository<Product> productRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> AddProductAsync(ProductDto product)
    {
        await _productRepository.InsertAsync(_mapper.Map<Product>(product));
        await _unitOfWork.CommitAsync();
        return true;
    }

    public async Task DeleteAsync(Guid id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product is null)
            throw new NullReferenceException("This product is not existing");
        _productRepository.Remove(product);
        await _unitOfWork.CommitAsync();
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductAsync()
    {
        var result = await _productRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductDto>>(result);
    }

    public async Task<bool> UpdateProductAsync(ProductDto product)
    {
        _productRepository.Update(_mapper.Map<Product>(product));
        await _unitOfWork.CommitAsync();
        return true;
    }
}