using AutoMapper;
using OnlineStore.Domain.Commons.Interface;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Features.Products.Commands;
public record AddNewProductRequest(ProductDto Product) : IRequest;

public sealed class AddNewProductRequestHandler : IRequestHandler<AddNewProductRequest>
{
    private readonly IMapper _mapper;
    private readonly IOnlineStoreRepository<Product> _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddNewProductRequestHandler(IMapper mapper,
            IOnlineStoreRepository<Product> productRepository,
            IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(AddNewProductRequest request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request.Product);
        await _productRepository.InsertAsync(product);
        await _unitOfWork.CommitChangesAsync();
    }
}