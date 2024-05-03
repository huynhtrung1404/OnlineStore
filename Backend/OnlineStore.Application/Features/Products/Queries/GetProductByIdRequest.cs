using AutoMapper;
using OnlineStore.Application.Specification;
using OnlineStore.Domain.Commons.Interface;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Features.Products.Queries;
public record GetProductByIdRequest(Guid Id) : IRequest<ProductDto>;
public sealed class GetProductByIdRequestHandler : IRequestHandler<GetProductByIdRequest, ProductDto>
{
    private readonly IOnlineStoreRepository<Product> _productRepository;
    private readonly IMapper _mapper;

    public GetProductByIdRequestHandler(IOnlineStoreRepository<Product> productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductDto> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
    {
        var result = await _productRepository.GetItemAsync(new ProductSpecification(request.Id));
        return _mapper.Map<ProductDto>(result);
    }
}
