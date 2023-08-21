using MediatR;
using OnlineStore.Application.Commons.Interfaces;
using OnlineStore.Application.DTOs;

namespace OnlineStore.Application.Features.Products.Queries;
public class GetAllProductRequest : IRequest<IEnumerable<ProductDto>>
{

}

public class GetAllProductRequestHandler : IRequestHandler<GetAllProductRequest, IEnumerable<ProductDto>>
{
    private readonly IProductService _productService;

    public GetAllProductRequestHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IEnumerable<ProductDto>> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
    {
        return await _productService.GetAllProductAsync();
    }
}