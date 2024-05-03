using AutoMapper;
using OnlineStore.Application.Specification;
using OnlineStore.Domain.Commons.Interface;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Features.Products.Commands;
public record RemoveProductRequest(Guid Id) : IRequest
{

}

public sealed class RemoveProductRequestHandler : IRequestHandler<RemoveProductRequest>
{
    private readonly IOnlineStoreRepository<Product> _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveProductRequestHandler(IOnlineStoreRepository<Product> productRepository, IUnitOfWork unitofWork)
     => (_productRepository, _unitOfWork) = (productRepository, unitofWork);

    public async Task Handle(RemoveProductRequest request, CancellationToken cancellationToken)
    {
        var data = await _productRepository.GetItemAsync(new ProductSpecification(request.Id));
        if (data is null)
            throw new ArgumentNullException("Product is not existed");
        _productRepository.Remove(data);
        await _unitOfWork.CommitChangesAsync();
    }
}