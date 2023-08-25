using MediatR;
using OnlineStore.Application.Commons.Interfaces;
using OnlineStore.Application.DTOs;

namespace OnlineStore.Application.Features.Products.Commands;
public record UpdateProductRequest(ProductDto Product) : IRequest<bool>
{

}

public sealed class UpdateProductRequestHandler : IRequestHandler<UpdateProductRequest, bool>
{
    private readonly IProductService _productService;

    public UpdateProductRequestHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<bool> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var result = await _productService.UpdateProductAsync(request.Product);
        return result;
    }
}