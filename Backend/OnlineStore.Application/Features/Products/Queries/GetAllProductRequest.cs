using AutoMapper;
using OnlineStore.Application.Responses;
using OnlineStore.Application.Specification;
using OnlineStore.Domain.Commons.Interface;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Features.Products.Queries;
public record GetAllProductRequest(long PageSize, long PageNumber) : IRequest<ListResponse<ProductDto>> { }

public sealed class GetAllProductRequestHandler : IRequestHandler<GetAllProductRequest, ListResponse<ProductDto>>
{
    private readonly IOnlineStoreRepository<Product> _productRepository;
    private readonly IMapper _mapper;

    public GetAllProductRequestHandler(IOnlineStoreRepository<Product> productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ListResponse<ProductDto>> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetListAsync(new ProductSpecification(request.PageSize, request.PageNumber, true));
        var count = await _productRepository.CountAsync(new ProductSpecification());
        return new()
        {
            Response = _mapper.Map<IEnumerable<ProductDto>>(products),
            PageSize = request.PageSize,
            PageNumber = request.PageNumber,
            TotalCount = count
        };
    }
}