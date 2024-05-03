using OnlineStore.Domain.Commons.Interface;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Features.Products.Commands;
public record UpdateProductRequest(ProductDto Product) : IRequest<bool>;

public sealed class UpdateProductRequestHandler : IRequestHandler<UpdateProductRequest, bool>
{
    private readonly IMapper _mapper;
    private readonly IOnlineStoreRepository<Product> _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductRequestHandler(IMapper mapper, IOnlineStoreRepository<Product> productRepository, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var data = _mapper.Map<Product>(request.Product);
        _productRepository.Update(data);
        await _unitOfWork.CommitChangesAsync();
        return true;
    }
}