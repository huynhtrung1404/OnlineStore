namespace OnlineStore.Application.Features.Products.Queries;
public record GetProductByIdRequest(Guid Id) : IRequest<ProductDto>;
public sealed class GetProductByIdRequestHandler : IRequestHandler<GetProductByIdRequest, ProductDto>
{
    private readonly IProductService _productService;

    public GetProductByIdRequestHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<ProductDto> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
    {
        return await _productService.GetProductByIdAsync(request.Id);
    }
}

